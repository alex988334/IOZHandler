using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.ExportModule.SQLModule
{
    public class Group: RootClass
    {
        private String stage;
        private String layerName;
        private String lastLayer;
        private String aliasName;
        private String tableAlias;        
        private Dictionary<String, List<Filter>> filters;

        private Dictionary<String, String>.Enumerator enumeretor;
        private Dictionary<String, String> whereSQL; 
        
        public Group(String sqlTableAlias)
        {
            filters = new Dictionary<String, List<Filter>>();
            tableAlias = sqlTableAlias;
            
        }

        public KeyValuePair<String, String> getCurrentWhere() 
        {
            if (whereSQL == null)
            {
                generateWhere();
            }
            
            return enumeretor.Current;
        }

        public bool moveNext()
        {
            return enumeretor.MoveNext();
        }

        public void validate()
        {
            if (stage == null || stage.Length == 0 || layerName == null || layerName.Length == 0 ||
                lastLayer == null || lastLayer.Length == 0 || filters == null || filters.Count == 0 ||
                aliasName == null || aliasName.Length == 0)
            {
                throw new ArgumentException("Не заданы параметры SQL модели! Выполнение прервано.");
            }

            String[] keys = filters.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = 0; j < filters[keys[i]].Count; j++)
                {
                    filters[keys[i]][j].validate();
                }
            }
        }

        public void generateWhere()
        {
            
            String[] keys = filters.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                String where = "";
                for (int j = 0; j < filters[keys[i]].Count; j++)
                {
                    where = where + generateCondition(filters[keys[i]][j], /* (j == 0) ? true :*/ false);
                }
                if (whereSQL == null)
                {
                    whereSQL = new Dictionary<String, String>();
                }
                whereSQL[keys[i]] = where;
            }

            generateEnumerator();
        }

        public void generateEnumerator()
        {
            enumeretor = whereSQL.GetEnumerator();
        }

        private String generateCondition(Filter filter, bool first)
        {
            String cond = " " + filter.logicOperator + " ";
            if (first) 
            {
                cond = " ";
            }
            String byRef = "";
            if (filter.dictionField)
            {
                byRef = "BYREF ";
            }

            cond = cond + byRef + tableAlias + ".[" + filter.field + "] " + filter.value;

            return cond;
        }

        private void addFilter(String aliasFile, Filter filter)
        {
            filters[aliasFile].Add(filter);
        }

        public override string ToString()
        {
            String str = "{\n"
                    + "\tэтап: " + stage + ",\n"
                    + "\tслой: " + layerName + ",\n"
                    + "\tслой сущ: " + lastLayer + ",\n"
                    + "\tпсевдоним таблицы: " + tableAlias + ",\n"
                    + "\tфильтры: {\n";

            String[] keys = filters.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                str = str + "\t\t" + keys[i]  + ": {\n";
                for (int j = 0; j < filters[keys[i]].Count; j++)
                {                    
                    str = str + filters[keys[i]][j].ToString() + "\n";
                    
                }
                str = str + "\t\t}\n";
            }
            str = str + "\t}\n";


            return str;
        }

        public void setFilters(Dictionary<String, List<Filter>> filters)
        {
            this.filters = filters;

        
        }

        public void setStage(String stage)
        {
            this.stage = stage;
        }
        public void setLayerName(String layerName)
        {
            this.layerName = layerName;
        }
        public void setLastLayer(String lastLayer)
        {
            this.lastLayer = lastLayer;
        }
        public void setTableAlias(String tableAlias)
        {
            this.tableAlias = tableAlias;
        }
        public void setAliasName(String aliasName)
        {
            this.aliasName = aliasName;
        }

        public String getAliasName()
        {
            return this.aliasName;
        }
        public String getStage()
        {
            return stage;
        }
        public String getLayerName()
        {
            return layerName;
        }
        public String getLastLayer()
        {
            return lastLayer;
        }
        public Dictionary<String, List<Filter>> getFilters()
        {
            return filters;
        }
    }
}
