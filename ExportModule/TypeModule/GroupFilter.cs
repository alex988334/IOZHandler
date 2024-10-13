using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace Example2.ExportModule.TypeModule
{
    public class GroupFilter
    {        
        public String fieldName {  get; set; }
        private List<String> aliases;
        private bool exceptionValues;
        private bool allValues;
        private bool dictionField;
        private List<String> values;
        private String tableAlias;
        private List<String>.Enumerator enumer;

        public GroupFilter(): this("")
        {
        }
        
        public GroupFilter(String fieldName): this(fieldName, "")
        {   
        }

        public GroupFilter(String fieldName, String tableAlias): this(fieldName, false, true, tableAlias, null)
        {            
        }

        public GroupFilter(String fieldName, bool exceptionValues, bool allValues, String tableAlias, List<String> values)
        {
            this.fieldName = fieldName;
            this.exceptionValues = exceptionValues;
            this.allValues = allValues;
            this.tableAlias = tableAlias;
            this.values = values;
            this.dictionField = false;
        }

        public String serializeJSON()
        {
            String str = "";

            str += "\"" + nameof(fieldName) + "\":\"" + fieldName + "\",";
            
            String line = "";

            for (int i = 0; i < aliases.Count; i++)
            {
                line += "\"" + aliases[i] + "\"";
                if (i < aliases.Count - 1)
                {
                    line += ", ";
                }
            }
            str += "\"" + nameof(aliases) + "\":[" + line + "],";

            str += "\"" + nameof(exceptionValues) + "\":" + exceptionValues.ToString() + ",";

            str += "\"" + nameof(allValues) + "\":" + allValues.ToString() + ",";

            str += "\"" + nameof(tableAlias) + "\":\"" + tableAlias + "\",";

            if (values != null)
            {
                line = "";
                for (int i = 0; i < values.Count; i++)
                {
                    line += "\"" + values[i] + "\"";
                    if (i < values.Count - 1)
                    {
                        line += ", ";
                    }
                }
                str += "\"" + nameof(values) + "\":[" + line + "]";
            } else
            {
                str += "\"" + nameof(values) + "\":null";
            }
            
            str = "{" + str + "}";

            return str;
        }

        public void setFieldName(String fieldName)
        {
            this.fieldName = fieldName;
        }
        public List<String> getAliases()
        {
            return aliases;
        }
        public void setAliases(List<String> aliases)
        {
            this.aliases = aliases;
        }

        public String getFieldName()
        {
            return fieldName;
        }
        public bool isExceptionValues()
        {
            return exceptionValues;
        }
        public bool isAllValues()
        { 
            return allValues;
        }
        public List<String> getValues()
        {
            if (values == null)
            {
                return new List<String>();
            }

            return values;
        }
        public String getTableAlias()
        {
            return tableAlias;
        }
        public void setAllValues(bool allValues)
        {
            this.allValues = allValues;
        }
        public void setExceptionValues(bool exceptionValues)
        {
            this.exceptionValues = exceptionValues;
        }
        public void setValues(List<String> values)
        {            
            this.values = values;
        }

        public void removeValue(int index)
        {
            values.RemoveAt(index);
        }
        public void addValue(String value)
        {
            if (values == null)
            {
                values = new List<String>();
            }
            values.Add(value);
        }

        public void initEnumeration()
        {
            enumer = values.GetEnumerator();
        }

        public bool moveNext()
        {
            return enumer.MoveNext();
        }

        public void removeAllValues()
        {
            values = null;
        }

        public void setDictionField(bool dictionField)
        {
            this.dictionField = dictionField;
        }

        public (String, String) generateCurrentWhere()
        {
            String name = enumer.Current;
            bool numeric = Regex.IsMatch(enumer.Current, "^[0-9]$");
                                    
            String where = " ByVal " + ((tableAlias.Length > 0) ? tableAlias + "." : "") 
                    + "[" + fieldName + "] = " + (numeric ? "" : "\"") + enumer.Current + (numeric ? "" : "\"");

            return (where, name);
        }

        public String getAliasesStr()
        {
            String alias = "";

            for (int i = 0; i < aliases.Count; i++)
            {
                alias += aliases[i];
                if (i < aliases.Count - 1)
                {
                    alias += "; ";
                }
            }

            return alias;
        }

        
    }
}
