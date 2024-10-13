using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.SupportClasses;

namespace Example2
{
    internal static class SQLCreater
    {
        public const String AND = "AND";
        public const String AND_RUS = " И ";
        public const String OR = "OR";
        public const String OR_RUS = "ИЛИ";
        public const String NOT = "NOT";
        public const String NOT_RUS = "НЕ";
        public const String NULL = "NULL";
        public const String NULL_RUS = "ПУСТО";
        public const String NOT_NULL_RUS = "НЕ ПУСТО";
        public const String WHERE = "WHERE";
        public const String SELECT = "SELECT";
        public const String FROM = "FROM";
        private static String[] AND_KEYS = { AND, AND_RUS };
        private static String[] OR_KEYS = { OR, OR_RUS };
        private static String aliasTable;

        public static void setAliasTable(String alias)
        {
            aliasTable = alias;
        }

        public static String parserWhere(String field, String Condition, bool byRefField)
        {
            String where = "";

            List<String> con = prepareCondition(Condition);
            con = replaceOperators(con);
            for (int i = 0; i < con.Count; i = i + 2)
            {
                con[i] = parseValues(field, con[i], byRefField);
            }

            if (con.Count == 1)
            {
                return con[0];
            }
            if (con.Count == 2)
            {
                return con[0];
            }

            return collectWhere(con);
        }

        private static String collectWhere(List<String> conditions)
        {            
            String coll = "";
            
            if (conditions.Count < 3)
            {
                return conditions[0];
            }
            
            for (int i = 1; i < conditions.Count; i = i + 2)
            {
                String otkPrior = "", zakPrior = "", zakPrior2 = "", lastVal = "";

                bool isOr = conditions[i].Equals(OR);
                bool prevIsOr = (i > 1) ? conditions[i - 2].Equals(OR) : false;

                if ((i == 1 && isOr) || (i > 1 && !prevIsOr && isOr))
                {
                    otkPrior = "(";                   
                }
                if (i > 1 && !isOr && prevIsOr)
                {
                    zakPrior = ")";
                }
                if (i + 2 == conditions.Count)
                {
                    lastVal = conditions[i + 1];
                }
                if (isOr && i + 2 == conditions.Count)
                {
                    zakPrior2 = ")";
                }

                coll = coll + " " + otkPrior + conditions[i - 1] + zakPrior + " " + conditions[i] + " " + lastVal + zakPrior2;
            }

            return coll;
        }

        public static List<String> replaceOperators(List<String> splitCondit)
        {
            for (int i = 0; i < splitCondit.Count; i++)
            {
                if (splitCondit[i].Equals(AND_RUS, StringComparison.Ordinal))
                {
                    splitCondit[i] = AND;
                }
                if (splitCondit[i].Equals(OR_RUS, StringComparison.Ordinal))
                {
                    splitCondit[i] = OR;
                }
            }

            return splitCondit;
        }

        public static List<String> prepareCondition(String condition)
        {
            List<String> l = new List<String>();            
            String typeFind = ""; 
            int ind = 0, indFind = -1;
            String[] keys = AND_KEYS.Concat(OR_KEYS).ToArray();
            int length = condition.Length;
            do
            {
                (typeFind, indFind) = findKey(keys, condition, ind);
                if (indFind > -1)
                {
                    if (indFind - ind > 0)
                    {
                        l.Add(condition.Substring(ind, indFind - ind).Trim());
                        l.Add(typeFind);
                    }                    
                    ind = indFind + typeFind.Length;
                } else if (indFind == -1 && l.Count > 0)
                {
                    l.Add(condition.Substring(ind + typeFind.Length, condition.Length - ind).Trim());
                    break;
                } else if (indFind == -1 && l.Count == 0)
                {
                    l.Add(condition);
                    break;
                }               
            } while (true);

            return l;
        }


        private static (String type, int index) findKey(String[] findKeys, String condition, int startFindInd)
        {
            int minInd = -1;
            String minOper = "";

            for (int i = 0; i < findKeys.Length; i++)
            {


                int ind = condition.IndexOf(findKeys[i], startFindInd, StringComparison.Ordinal);
                if ((ind > -1 && minInd == -1) || (ind > -1 && ind < minInd))
                {
                    minInd = ind;
                    minOper = findKeys[i];
                }
            }
            return (minOper, minInd);
        }


        private static String parseValues(String field, String value, bool byRefField)
        {  
            if (value.Contains("<") || value.Contains(">"))
            {
                throw new Exception("НЕ реализовано! private static String parseValues(String field, String value)");
            }

            if (field.Contains("Этап", StringComparison.OrdinalIgnoreCase) && !value.Contains("\""))
            {
                value = "\"" + value.Replace(",", "\",\"") + "\"";
            }


            String fie = "[" + field + "]";
            if (byRefField)
            {
                fie = "BYREF " + aliasTable + fie;
            } else
            {
                fie = aliasTable + fie;
            }

            if (value.Contains("*"))
            {
                return  fie + " LIKE \"" + value.Replace("*", "%") + "\"";
            }

            if (value.Contains(NOT_NULL_RUS, StringComparison.Ordinal))
            {
                return  fie + " IS NOT NULL";
            }
            if (value.Contains(NULL_RUS, StringComparison.Ordinal))
            {
                return fie + " IS NULL";
            }

            if (value.Contains(NOT_RUS, StringComparison.Ordinal))
            {
                return fie + " NOT IN (" + value.Replace(NOT_RUS, "").Trim() + ")";
            }

            return fie + " IN (" + value + ")";
        }


        public static String generateSelect(String[]? fields)
        {
            String sel = SELECT + " ";
            if (fields == null || fields.Length == 0)
            {
                return sel + " *";
            } 

            for(int i = 0; i < fields.Length; i++)
            {
                sel = sel + "[" + fields[i] + "]";
                if (i < fields.Length - 1)
                {
                    sel = sel + ", ";
                }
            }    
            return sel;
        }
        
        public static String generateFrom(String nameTable)
        {
            if (nameTable == null || nameTable.Length == 0)
            {
                throw new ExceptionSQL("Не задана таблица!");
            }
            return FROM + " [" + nameTable + "]";
        }
    }
}
