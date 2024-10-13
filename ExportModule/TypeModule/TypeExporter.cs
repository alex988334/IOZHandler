using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.ExportModule;
using Example2.ExportModule.SQLModule;
using Example2.LogModule;
using Example2.SupportClasses;
using ZB;
using ZuluLib;

namespace Example2.ExportModule.TypeModule
{
    internal class TypeExporter : Exporter
    {
        protected int countObjLayer;
        protected int countObjType;
        protected int countObjMode;

        protected string type, mode, etap;
        protected int? typeId, modeId = null;
        protected string rootPath, netPath, typePath, modePath, exportPath;
        protected bool rootPathF, netPathF, typePathF, modePathF;

        public const int ZB_FULL_NAME = 1;
        protected List<GroupFilter> groupFilters;
        //private string exportPath = "O:\\tmp_zulu\\";
        private string currentPath;


        public override void run()
        {
            exportPath = "O:\\tmp_zulu\\";

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

            //handlingTypes();
        }

        private void exportBySQL()
        {
            
            /**** вынести в control!!! ***/

            enableStructMapDoc();


            /***                */
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

    /*    private string[] getExportedTypes()
        {
            List<string> types = new List<string>();
            ObjectTypes t = layer.getZuluLayer().ObjectTypes;
            for (int i = 1; i < t.Count; i++)
            {
                types.Add(t.GetItemByIndex(i).Name);
            }

            return types.ToArray();
        }*/

        private void enableStructMapDoc()
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
        }

        private List<GroupFilter> initGroupFilters(int indexDB)
        {
            Layer l = layer.getZuluLayer();

            String typeN = l.Bases[indexDB].UserName;

            List<GroupFilter> rezult = findedFields();

            initValuesGroupFilters(rezult);

            return rezult;
        }

        private void initValuesGroupFilters(List<GroupFilter> filters)
        {
            IZbFields fields = db.ActiveQuery.VisualQuery.Fields;

            for (int i = 0; i < filters.Count; i++)
            {                
                String fieldName = filters[i].getFieldName();
                int ind = fields.GetIndexByName(ZB.zbNameType.zbFullName, fieldName);
                if (ind == -1)
                {
                    throw new KeyNotFoundException("Не найдено поле " + fieldName + " в базе данных " + db.UserName);
                }

                IZbBookInfo book =  fields[ind].Book;
                if (book == null)
                {
                    continue;
                }
                filters[i].setDictionField(true);

                IZbDataset data = book.GetDataset();
                if (data.MoveFirst())
                {
                    List<String> val = new List<String>();
                    do
                    {
                        val.Add(data.FieldValue[1]);
                    } while (data.MoveNext());

                    if (val.Count == 0)
                    {
                        throw new ArgumentNullException("Значения поля " + filters[i] + ", базы данных " 
                                + db.UserName + ", в словаре не найдены!");
                    }

                    filters[i].setValues(val);
                }
            }
        }


        private List<GroupFilter> findedFields()
        {
            List<GroupFilter> rezult = new List<GroupFilter>();
            
            IZbFields fields = db.ActiveQuery.VisualQuery.Fields;

            for (int k = 0; k < groupFilters.Count; k++)
            {
                int ind = findField(fields, groupFilters[k].getFieldName());
                if (ind == -1)
                {
                    List<String> aliases = groupFilters[k].getAliases();
                    for (int i = 0; i < aliases.Count; i++)
                    {
                        ind = findField(fields, aliases[i]);
                        if (ind > -1)
                        {
                            GroupFilter g = groupFilters[k];
                            GroupFilter gr = new GroupFilter(aliases[i], g.isExceptionValues(), g.isAllValues(), g.getTableAlias(), g.getValues());
                            rezult.Add(gr);
                            break;
                        }
                    }
                    if (ind == -1)
                    {
                        messageC("Не удалось найти поле \"" + groupFilters[k].getFieldName()
                                + "\" во время обработки слоя " + layer.getName() + ", базы данных "
                                + db.UserName + "\nПоле исключено из выборки базы данных", new int[] { errCode() });
                    }
                }
                else
                {
                    rezult.Add(groupFilters[k]);
                }
            }

            return rezult;
        }

        private int findField(IZbFields fields, String fieldName)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (String.Equals(fieldName, fields[i].Name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        private void exportZuluType(int indexDB)
        {
            db = layer.getZuluLayer().Bases[indexDB].Open();

            List<GroupFilter> filters = initGroupFilters(indexDB);

            int interation = 1;
            for (int j = 0; j < filters.Count; j++)
            {
                interation *= filters[j].getValues().Count;
                filters[j].initEnumeration();                
            }
            messageC("Количество интераций для типа \"" + db.UserName + "\" составляет " + interation, new int[] {boldCode(), warnCode()});
            for (int k = 0; k < interation; k++)
            {
                (String condition, String conditionName) rez = generateCondition(filters);
                String query = generateQuery(indexDB);
                query += rez.condition;
          
                selectObjects(query);

                exportDxf(indexDB, rez.conditionName);
                messageC("Осталось интераций " + (interation - k), new int[] { boldCode(), warnCode() });
            }
            db.Close(true);
        }

        private void exportDxf(int indDb, String unitName)
        {
            Layer l = layer.getZuluLayer();

            if (layer.getZuluLayer().Selection.ElementKeys.Count > 0)
            {
                string aliasType = l.Bases[indDb].UserName;

                string fileName = ZoneInterator.getNameCurrentZone() + "_" + layer.getNetName() + "_"
                        + aliasType + "_" + unitName;

                if (false /*!map.ExportToDxf(currentPath + "\\" + fileName + ".dxf", pathConfFile, 11)*/)
                {
                    messageC("Не удалось экспортировать в DXF! Имя экспортируемого файла: " + fileName,
                            new int[] { ILogEnums.errCode() });
                }
                else
                {
                    messageC("Файл создан: " + fileName, new int[] { boldCode(), italCode() });
                }
               
                l.Selection.Clear();
            }
        }


        private void selectObjects(String query)
        {
            message("Запрос => " + query);

            IZSqlResult r = map.ExecSQL(query);
            if (r.RetCode != 0)
            {
                messageC("Экспортирование в файл прервано! Ошибка SQL! " + r.ErrorString, new int[] { errCode() });
            }
            messageC("Выделено объектов: " + layer.getZuluLayer().Selection.ElementKeys.Count, new int[] { boldCode() });
        }

        private String generateQuery(int indexDB)
        {
            String typeName = layer.getZuluLayer().Bases[indexDB].UserName;

            string query = "ALTER SELECTION ON [" + layer.getZuluLayer().UserName
                    + "] ADD SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
                    + "] AS L2 WHERE L2.sys = " + ZoneInterator.getCurrentZone() + " AND L1.Geometry.STIntersects(L2.Geometry) AND L1.typename=\""
                    + typeName + "\"";

            return query;   
        }

        private (String, String) generateCondition(List<GroupFilter> filters)
        {
            String condition = "";
            String conditName = "";

            for (int h = 0; h < filters.Count; h++)
            {
                if (!filters[h].moveNext())
                {
                    filters[h].initEnumeration();
                    filters[h].moveNext();
                }
                (String where, String name) cond = filters[h].generateCurrentWhere();
                conditName += cond.name;
                condition += cond.where;
                if (h < filters.Count - 1)
                {
                    condition += " AND ";
                    conditName += "_";
                }
            }

            return ((condition.Length > 0) ? " AND " + condition : "", (condition.Length > 0) ? "_" + conditName : "");
        }

        private void exportZone()
        {
            Layer l = layer.getZuluLayer();

            for (int i = 0; i < l.Bases.Count; i++)
            {
                if (excludedTypes.ContainsKey(l.Bases[i].UserName))
                {
                    messageC("Тип \"" + l.Bases[i].UserName + "\", слоя " + l.UserName + " был исключен из экспорта пользователем", 
                            new int[] { warnCode() });
                    continue;
                }

                exportZuluType(i);
            }           
        }


        private bool findIntersect(int borderId)
        {
            string query = "SELECT l1.SYS FROM [" + layer.getZuluLayer().UserName + "] AS L1, [" + pptBorderLayer.getZuluLayer().UserName
                      + "] AS L2 WHERE L2.sys = " + borderId + " AND L1.Geometry.STIntersects(L2.Geometry) LIMIT 1";

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


        private void setInterator()
        {
            if (pptSelectedObjects != null && pptSelectedObjects.Length > 0)
            {
                ZoneInterator = new SelectedBorderInterator(pptBorderLayer.getZuluLayer(), pptSelectedObjects);
                return;
            }

            ZoneInterator = new BorderInterator(pptBorderLayer.getZuluLayer());
        }

        public override string[] getFileTypes()
        {
            return new string[] { FILE_DXF };
        }

        public void setFilterList(List<GroupFilter> groupFilters)
        {
            this.groupFilters = groupFilters;
        }
/*
        public void setFilterList(List<GroupFilter> groupFilters)
        {
            this.groupFilters = groupFilters;
        }


        private void handlingTypes()
        {
            ObjectTypes types = layer.getTypes();
            for (int i = 0; i < types.Count; i++)
            {
                type = cleanString(types.GetItemByIndex(i).Name);
                createPath(MODE_TYPE);
                handlingModes(types.GetItemByIndex(i).Modes, types.GetItemByIndex(i).Id);
            }
        }

        

        private void handlingModes(IObjectModes modes, int typeId)
        {
            for (int i = 1; i <= modes.Count; i++)
            {
                mode = cleanString(modes[i].Name);

                createPath(MODE_MODE);
                handlingEtap(modes[i], typeId, modes[i].Id);
            }
        }

        private void handlingEtap(IObjectMode mode, int typeId, int modeId)
        {
            Layer l = layer.getZuluLayer();
            l.Selection.Clear();

            string query = "SELECT DISTINCT [этап] FROM [" + layer.getName() + "] WHERE typeid = " + typeId + " AND modeid = " + modeId + " AND [этап] IS NOT NULL";
            //   message(query);
            IZSqlResult r = l.ExecSQL(query);

            if (r.RetCode != 0)
            {
                messageC(r.ErrorString + "\nquery => " + query, new int[] { ILogEnums.errCode() });
                return;
            }

            if (r.DataSet.MoveFirst())
            {
                do
                {
                    //db.se
                    query = "ALTER SELECTION ON [" + layer.getName() + "] ADD SELECT Sys WHERE typeid = " + typeId +
                            " AND modeid = " + modeId + " AND [этап] = \"" + r.DataSet.FieldValue[0] + "\"";

                    l.ExecSQL(query);
                    messageC(query, new int[] { ILogEnums.errCode() });

                    string fName = layer.getNetName() + "_" + type + "_" + this.mode + "_" + r.DataSet.FieldValue[0];

                    //    l.

                    //   l.CopyLayer(exportPath, fName, 80000000);    
                } while (r.DataSet.MoveNext());
            }

        }

        private void createPath(int mode)
        {
            if (mode == MODE_NET)
            {
                netPath = rootPath + DELIMETR + net;
                typePath = "";
                modePath = "";

                exportPath = netPath + "";
            }

            if (mode == MODE_TYPE)
            {
                typePath = netPath + DELIMETR + type;
                modePath = "";

                exportPath = typePath + "";
            }

            if (mode == MODE_MODE)
            {
                modePath = typePath + DELIMETR + this.mode;

                exportPath = modePath + "";
            }

            createDirectory(exportPath);
        }*/
    }
}
