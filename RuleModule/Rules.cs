using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.RuleModule
{
    internal class Rules: RootClass
    {
        private String pathRule;
        private Dictionary<String, String> rules;
        public const String SEPARATE = " => ";
        private const String DELIMETER = ";";
       

        public Rules(String mapPath)
        {
            pathRule = mapPath.Replace(".zmp", ".rule");

            if (!File.Exists(pathRule))
            {
                message("pathRule => " + pathRule);
                FileStream s = File.Create(pathRule);
                s.Close();                
            }

            readRules();
        }

        public String[] getKeys()
        {
            if (rules == null)
            {
                return new String[] { };
            }
            return rules.Keys.ToArray();
        }

        public void readRules()
        {
            rules = new Dictionary<string, string>();
            String[] lines = File.ReadAllLines(pathRule);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Equals(""))
                {
                    String[] kv = lines[i].Split(SEPARATE);
                    rules[kv[0]] = kv[1];
                }                
            }
        }

        public String getLayer(String sampleLayName)
        {
            if (rules.ContainsKey(sampleLayName))
            {
                return rules[sampleLayName];
            }
            return sampleLayName;
        }

        public String getType(String sampleLayName, String sampleTypeName)
        {
            String key = sampleLayName + DELIMETER + sampleLayName;
            if (rules.ContainsKey(key))
            {
                return rules[key];
            }
            return sampleTypeName;
        }

        public String getAttr(String sampleLayName, String sampleTypeName, String sampleAttrName)
        {
            String key = sampleLayName + DELIMETER + sampleTypeName + DELIMETER + sampleAttrName;
            if (rules.ContainsKey(key))
            {
                return rules[key];
            }
            return sampleAttrName;
        }

        public bool createRule(String layerName, String value)
        {            
            return createRule(layerName, null, null, value);
        }

        public bool createRule(String layerName, String typeName, String value)
        {            
            return createRule(layerName, typeName, null, value);
        }

        public bool createRule(String layerName, String typeName, String attrName, String value)
        {
            String key = layerName;
            String rule = layerName;

            if (typeName != null)
            {
                key = key + DELIMETER + typeName;
                rule = rule + DELIMETER + typeName;
            }
            if (attrName != null)
            {
                key = key + DELIMETER + attrName;
                rule = rule + DELIMETER + attrName;
            }
            
            rule = rule + SEPARATE + value;
            if (writeFile(rule))
            {
                rules[key] = value;
                return true;
            }
            return false;
        }

        private bool writeFile(String rule)
        {
            try
            {
                StreamWriter w = new StreamWriter(pathRule, true);
                w.WriteLine(rule);
                w.Close();
                return true;
            }catch (Exception e)
            {
                messageC("Записать правило в файл не удалось! Правило: " + rule + ", файл: " + pathRule
                        + "\ne.message => " + e.Message, new int[] { errCode() });
                return false;
            }
        }

        public void deleteRule(String key)
        {
            String k = key + SEPARATE + rules[key];
            String[] lines = File.ReadLines(pathRule).ToArray();

            File.WriteAllText(pathRule, string.Empty);

            StreamWriter w = new StreamWriter(pathRule, true);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!k.Equals(lines[i]))
                {                    
                    w.WriteLine(lines[i]);                    
                }
            }
            w.Close();           
        }

        public String ToString()
        {
            String str = "Правила: {\n";
            String[] keys = rules.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                str = str + "\t" + keys[i] + SEPARATE + rules[keys[i]] + "\n";
            }
            str = str + "}";

            return str;
        }

    }
}
