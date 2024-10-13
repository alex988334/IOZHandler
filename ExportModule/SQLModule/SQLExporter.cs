using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZuluLib;
using Example2.SupportClasses;
using Example2.LogModule;

namespace Example2.ExportModule.SQLModule
{
    internal class SQLExporter : Exporter
    {
        private Dictionary<string, Group> parametrs;
        private string exportPath = "O:\\tmp_zulu\\";
        private string currentPath;

        public override string[] getFileTypes()
        {
            return new string[] { FILE_DXF };
        }

        public void setParams(Dictionary<string, Group> parametrs)
        {
            this.parametrs = parametrs;
        }

        public override void run()
        {
            if (pptBorderLayer == null)
            {
                messageC("Не установлен слой с границами ППТ!", new int[] { errCode() });
                return;
            }
            if (exportType != FILE_DXF)
            {
                throw new Exception("Функционал не реализован!! exportByThemes()");
            }

            setInterator();

            exportBySQL();
        }

        private void exportBySQL()
        {
            do
            {
                if (findIntersect(ZoneInterator.getCurrentZone()))
                {
                    currentPath = exportPath + ZoneInterator.getNameCurrentZone();

                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }

                    exportZone();
                }
            } while (ZoneInterator.moveNext());
        }

        private string[] getExportedTypes()
        {
            ObjectTypes t = layer.getZuluLayer().ObjectTypes;
            String[] types = new string[t.Count];
            for (int i = 0; i < (t.Count); i++)
            {
                types[i] = t.GetItemByIndex(i).Name;
            }
            
            /* для ТС
             * 
             * return new string[] { "Участки", "Узел", "Обобщенный потребитель" };
             * */

            // для ВС
           // return new string[] { "Потребитель", "Узел", "Водопроводный колодец с гидрантом", "Участок водопроводной сети" };

            return types;
        }

      /*  private string[] getMeropriyatiya()
        {
            return new string[] { "строительство", "демонтаж" };
        }*/

        private void exportZone()
        {
            Layer l = layer.getZuluLayer();

            int ids = l.Themes.GetIdByName(themeName);
            if (ids <= 0)
            {
                throw new Exception("Не реализованно! exportByThemes()");
            }
            l.Themes.SetEnabled(ids, true);

            for (int i = 0; i < l.LabelLayers.Count; i++)
            {
                if (annotationExport.Contains(l.LabelLayers[i].UserName))
                {
                    l.LabelLayers[i].Enable = true;
                }
            }

            string[] types = getExportedTypes();
            //    string[] meropriyat = getMeropriyatiya();
            Group gr = parametrs[layer.getName()];
            for (int i = 0; i < types.Length; i++)
            {
                while (gr.moveNext()) 
                {
                    var pairs = gr.getCurrentWhere();

                    selectionObjects(types[i], gr.getStage(), pairs.Value);

                    messageC("Всего выделено: " + l.Selection.ElementKeys.Count, new int[] { boldCode() });

                    if (l.Selection.ElementKeys.Count > 0)
                    {
                        string aliasType = types[i];
                      /*  для ТС
                       *  
                       *  if (types[i].Equals("Узел"))
                        {
                            aliasType = "Камеры";
                        }
                        if (types[i].Equals("Обобщенный потребитель"))
                        {                            
                            aliasType = "Потребители";
                        }*/

                        exportSelection(ZoneInterator.getNameCurrentZone() + "_" + layer.getNetName() + "_"
                                + aliasType + "_" + pairs.Key + "_" + gr.getAliasName());
                        l.Selection.Clear();
                    }
                }
                gr.generateEnumerator();
            }

            if (l.UserName.Equals(gr.getLastLayer()))
            {
                for (int i = 0; i < types.Length; i++)
                {
                    selectionExsistObjects(types[i], gr.getStage());

                    messageC("Всего выделено: " + l.Selection.ElementKeys.Count, new int[] { boldCode() });

                    if (l.Selection.ElementKeys.Count > 0)
                    {
                        string aliasType = types[i];
                      /*  
                       *  для ТС
                       *  
                       *  if (types[i].Equals("Узел"))
                        {
                            aliasType = "Камеры";
                        }
                        if (types[i].Equals("Обобщенный потребитель"))
                        {
                            aliasType = "Потребители";
                        }*/

                        exportSelection(ZoneInterator.getNameCurrentZone() + "_" + layer.getNetName() + "_"
                                + aliasType + "_сущ_итог");
                        l.Selection.Clear();
                    }
                }
            }

            /*
            foreach (TreeNode layerNode in groupConditRules.Nodes)
            {
                if (!layer.getName().Equals(layerNode.Text))
                {
                    continue;
                }

                foreach (TreeNode themeNode in layerNode.Nodes)
                {
                    int id = l.Themes.GetIdByName(themeNode.Name);
                    if (id == -1)
                    {
                        continue;
                    }
                    messageC("Тема: " + themeNode.Text, new int[] { boldCode(), italCode() });

                    int idFiltr = l.Themes.ThemeFilterId[id];
                    ThemeFilterDesc filt = l.ThemeFilters.GetItemById(idFiltr);
                    String st = filt.UserName;

                    foreach (TreeNode ruleNode in themeNode.Nodes)
                    {
                        messageC("Группа фильтров: " + ruleNode.Text, new int[] { boldCode() });
                         
                        foreach (TreeNode conditNode in ruleNode.Nodes)
                        {
                            int index = -1;
                            for (int i = 0; i < filt.ConditionsCount; i++)
                            {
                                if (filt.ConditionName[i].Equals(conditNode.Name))
                                {
                                    index = i;
                                    break;
                                }
                            }
                            if (index == -1)
                            {
                                continue;
                            }
                            selectionObjects(filt, index);
                        }

                        messageC("Всего выделено: " + l.Selection.ElementKeys.Count, new int[] { boldCode() });

                        if (l.Selection.ElementKeys.Count > 0)
                        {
                            exportSelectionUpdatePoliterm(fileName);
                            l.Selection.Clear();
                        }
                    }
                }
            }*/
        }

        private void exportSelection(string fileName)
        {
            if (!map.ExportToDxf(currentPath + "\\" + fileName + ".dxf", pathConfFile, 11))
            {
                messageC("Не удалось экспортировать в DXF! Имя экспортируемого файла: " + fileName,
                        new int[] { ILogEnums.errCode() });
            }
            else
            {
                messageC("Файл создан: " + fileName, new int[] { boldCode(), italCode() });
            }
        }

        private bool findIntersect(int val)
        {
            string query = "SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
                      + "] AS L2 WHERE L2.sys = " + val + " AND L1.Geometry.STIntersects(L2.Geometry) LIMIT 1";

            IZSqlResult rez = map.ExecSQL(query);
            if (rez.RetCode != 0)
            {
                throw new ExceptionSQL(rez.ErrorString + ", query => " + query);
            }

            if (rez.DataSet.MoveFirst())
            {
                return true;
            }

            return false;
        }

        private void selectionExsistObjects(string typeName, string etap)
        {
            string query = "ALTER SELECTION ON [" + layer.getZuluLayer().UserName
            + "] ADD SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
            + "] AS L2 WHERE L2.sys = " + ZoneInterator.getCurrentZone() + " AND L1.Geometry.STIntersects(L2.Geometry) AND L1.typename=\""
                    + typeName + "\" AND (L1.[V_Etap] = \"существующие\" OR L1.[V_Etap] IS NULL)" /*where + excludedWhere**/;

            message("Запрос => " + query);

            IZSqlResult r = map.ExecSQL(query);
            if (r.RetCode != 0)
            {
                messageC("Экспортирование в файл прервано! Ошибка SQL! " + r.ErrorString, new int[] { errCode() });
            }
        }

        private void selectionObjects(string typeName, string etap, string where)
        {
            string fieldName = "V_Meropriyatiya";           

            if (typeName.Equals("Обобщенный потребитель"))
            {
                where = where.Replace(fieldName, "Мероприятия по ЦТП/ИТП");               
            }

            string query = "ALTER SELECTION ON [" + layer.getZuluLayer().UserName
                    + "] ADD SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
                    + "] AS L2 WHERE L2.sys = " + ZoneInterator.getCurrentZone() + " AND L1.Geometry.STIntersects(L2.Geometry) AND L1.typename=\""
                    + typeName + "\" AND L1.[V_Etap] =\"" + etap + "\" " + where /*where + excludedWhere**/;

            message("Запрос => " + query);

            IZSqlResult r = map.ExecSQL(query);
            if (r.RetCode != 0)
            {
                messageC("Экспортирование в файл прервано! Ошибка SQL! " + r.ErrorString, new int[] { errCode() });
            }
        }
        /*
                private String generateWhere(ThemeFilterDesc filt, int index)
                {


                    return where;
                }*/

        private void setInterator()
        {
            if (pptSelectedObjects != null && pptSelectedObjects.Length > 0)
            {
                ZoneInterator = new SelectedBorderInterator(pptBorderLayer.getZuluLayer(), pptSelectedObjects);
                return;
            }

            ZoneInterator = new BorderInterator(pptBorderLayer.getZuluLayer());
        }
    }
}
