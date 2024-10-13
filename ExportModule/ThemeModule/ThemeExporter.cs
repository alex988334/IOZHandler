using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuluLib;
using Example2.SupportClasses;
using Example2.LogModule;
using Example2.ExportModule;


namespace Example2.ExportModule.ThemeModule
{
    internal class ThemeExporter : Exporter
    {
        private MapDoc tempMap;
        //   private Layer tmpLabel;
        private ZuluTools tools;

        private string tmpPath;
        private string temp = "\\tmp";


        public override string[] getFileTypes()
        {
            return new string[] { FILE_DXF };
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

            exportPath = "O:\\Export";
            setInterator();

            exportByThemes();
        }

        private void setInterator()
        {
            if (pptSelectedObjects != null && pptSelectedObjects.Length > 0)
            {
                ZoneInterator = new SelectedBorderInterator(pptBorderLayer.getZuluLayer(), pptSelectedObjects);
                return;
            }

            ZoneInterator = new BorderInterator(pptBorderLayer.getZuluLayer());
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


        private void exportByThemes()
        {
            do
            {
                if (findIntersect(ZoneInterator.getCurrentZone()))
                {
                    exportZone();
                }
            } while (ZoneInterator.moveNext());
        }


        private void exportZone()
        {
            exportThemes();
            //exportGroupsConditions();
            exportGroupsConditionsPolitermUpdate();
        }

        private void exportThemes()
        {

        }


        private void exportGroupsConditionsPolitermUpdate()
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
                    string st = filt.UserName;

                    foreach (TreeNode ruleNode in themeNode.Nodes)
                    {
                        messageC("Группа фильтров: " + ruleNode.Text, new int[] { boldCode() });

                        string fileName = generateTempFileName(ruleNode.Name);
                        string filePath = generateFilePath(fileName);

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
            }
        }


        private void exportSelectionUpdatePoliterm(string fileName)
        {
            if (!map.ExportToDxf(exportPath + "\\" + fileName + ".dxf", pathConfFile, 11))
            {
                messageC("Не удалось экспортировать в DXF! Имя экспортируемого файла: " + fileName,
                        new int[] { ILogEnums.errCode() });
            }
            else
            {
                messageC("Файл создан: " + fileName, new int[] { boldCode(), italCode() });
            }
        }


        private void exportGroupsConditions()
        {
            Layer l = layer.getZuluLayer();
            generateTempMap();

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
                    string st = filt.UserName;

                    foreach (TreeNode ruleNode in themeNode.Nodes)
                    {
                        messageC("Группа фильтров: " + ruleNode.Text, new int[] { boldCode() });

                        string fileName = generateTempFileName(ruleNode.Name);
                        string filePath = generateFilePath(fileName);
                        if (stage == STAGE_SELECTION)
                        {
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

                            if (l.Selection.ElementKeys.Count > 0)
                            {
                                copySelection(filePath, fileName);
                                l.Selection.Clear();
                                prepareTempLayer(filePath);
                            }
                        }

                        if (stage == STAGE_EXPORT && File.Exists(filePath))
                        {
                            for (int i = 1; i <= tempMap.Layers.Count; i++)
                            {
                                tempMap.Layers.Remove(i);
                            }
                            Layer tempLayer = prepareTempLayer(filePath);
                            Layer tempLabel = prepareTempLabel(fileName);
                            exportToDxf(fileName);
                            terminate(tempLayer, tempLabel);
                        }
                    }
                }
            }
        }

        private void terminate(Layer tmpLayer, Layer tmpLabel)
        {
            tmpLayer.Selection.Clear();
            tmpLabel.Selection.Clear();

            tempMap.Layers.Remove(tmpLayer);
            tempMap.Layers.Remove(tmpLabel);

            tempMap.SaveAs(tmpPath + "\\tmp.zmp");
        }


        private void exportToDxf(string fileName)
        {
            if (!tempMap.ExportToDxf(exportPath + "\\" + fileName + ".dxf", pathConfFile, 3))
            {
                messageC("Не удалось экспортировать в DXF! Имя экспортируемого файла: " + fileName,
                        new int[] { ILogEnums.errCode() });
            }
            else
            {
                messageC("Файл создан: " + fileName, new int[] { boldCode(), italCode() });
            }
        }

        private string generateTempFileName(string groupName)
        {
            return ZoneInterator.getNameCurrentZone().Replace(",", "_") + "__" + layer.getName() + "__" + groupName;
        }

        private string generateFilePath(string fileName)
        {
            tmpPath = exportPath + temp;
            createDirectory(exportPath);
            createDirectory(tmpPath);

            return tmpPath + "\\" + fileName + ".b00";
        }

        private void selectionObjects(ThemeFilterDesc filt, int index)
        {
            string typeName = layer.getZuluLayer().Bases.ItemById[filt.BaseID[index]].UserName;
            string excludedWhere = "";

            if (excludedTypes != null && excludedTypes.ContainsKey(typeName))
            {
                if (excludedTypes[typeName].Count == 0)
                {
                    messageC("Исключенный из выборки тип: " + typeName, new int[] { warnCode() });
                    return;
                }
                else
                {
                    excludedWhere = " AND L1.[modename] NOT IN (";
                    string values = "";
                    for (int i = 0; i < excludedTypes[typeName].Count; i++)
                    {
                        values = values + "\"" + excludedTypes[typeName][i] + "\"";
                        if (i + 1 < excludedTypes[typeName].Count)
                        {
                            values = values + ", ";
                        }
                    }
                    excludedWhere = excludedWhere + values + ")";
                }
            }

            string where = generateWhere(filt, index);

            string query = "ALTER SELECTION ON [" + layer.getZuluLayer().UserName
            + "] ADD SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
            + "] AS L2 WHERE L2.sys = " + ZoneInterator.getCurrentZone() + " AND L1.Geometry.STIntersects(L2.Geometry) AND L1.typename=\""
                    + typeName + "\" AND " + where + excludedWhere;

            message("Название фильтра: " + filt.ConditionName[index] + ", запрос => " + query);

            IZSqlResult r = map.ExecSQL(query);
            if (r.RetCode != 0)
            {
                message(filt.ConditionName[index]);
                message("Экспортирование темы \"" + filt.ConditionName[index] + "\" прервано! Ошибка SQL!\n"
                        + r.ErrorString);
                message("query => " + query);
            }
        }

        private void copySelection(string pathFile, string fileName)
        {
            if (!layer.getZuluLayer().CopyLayer(pathFile, fileName, 80000000))
            {
                messageC("Копирование во временный слой завершилось ошибкой! Копируемый объект: " + fileName,
                        new int[] { ILogEnums.errCode() });
                return;
            }
        }

        private Layer prepareTempLayer(string pathFile)
        {
            Layer tmplayer = new Layer();
            tmplayer.Open(pathFile);
            tempMap.Layers.Add(tmplayer);

            int id = tmplayer.Themes.GetIdByName(themeName);
            if (id <= 0)
            {
                throw new Exception("Не реализованно! exportByThemes()");
            }

            tmplayer.Themes.SetEnabled(id, true);

            for (int i = 0; i < tmplayer.LabelLayers.Count; i++)
            {
                if (annotationExport.Contains(tmplayer.LabelLayers[i].UserName))
                {
                    tmplayer.LabelLayers[i].Enable = true;
                }
            }

            tempMap.SaveAs(tmpPath + "\\tmp.zmp");
            tmplayer.Selection.SelectAll();

            return tmplayer;
        }

        private Layer prepareTempLabel(string fileName)
        {
            Layer tmpLabel = new Layer();
            //createTempLabel(fileName);

            string path = tmpPath + "\\" + fileName + "_label.b00";
            tmpLabel.Open(path);

            tempMap.Layers.Add(tmpLabel);
            tempMap.SaveAs(tmpPath + "\\tmp.zmp");

            return tmpLabel;
        }

        private void generateTempMap()
        {
            if (tempMap == null)
            {
                tempMap = new MapDoc();
            }
        }


        private Layer createTempLabel(string fileName)
        {
            if (tools == null)
            {
                tools = new ZuluTools();
            }

            string rew = tmpPath + "\\" + fileName + "_label.b00";

            tools.LayerCreate(rew, fileName + "_label", eLayerType.eMixedLayer);
            Layer tmpLabel = new Layer();

            tmpLabel.Open(tmpPath + "\\" + fileName + "_label.b00");

            return tmpLabel;
        }


        private string generateWhere(ThemeFilterDesc filt, int index)
        {
            SQLCreater.setAliasTable("L1.");

            /*   String[] byrefFields = { "Мероприятия по ЦТП/ИТП", "V_KSIO", "Этап", "Наименование узла",
                       "Назначение участка", "Демонтаж в…", "Вид сети", "Назначение камеры", "Назначение источника" };
            */
            string where = "";

            //  for (int i = 0; i < filt.ConditionsCount; i++)
            //   {
            //    message(filt.ConditionName[i]);
            //      where = "";
            for (int j = 0; j < filt.FieldsCount[index]; j++)
            {
                string s = SQLCreater.parserWhere(filt.FieldName[index, j], filt.ConditionString[index, j],
                        byRefFields.Contains(filt.FieldName[index, j]));

                where = where + " " + (j == 0 ? " " : SQLCreater.AND) + " " + s;
            }
            //  }

            return where;
        }

    }
}
