using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.ExportModule.SQLModule
{
    public class Filter
    {
        public String logicOperator;
        public String field;
        public bool dictionField;
        public String value;
        public String nameGroup;


        public override string ToString()
        {
            return "\t\tоператор: " + logicOperator + ",\n"
                + "\t\tполе: " + field + ",\n"
                + "\t\tполе словаря: " + dictionField + ",\n"
                + "\t\tзначение: " + value + ",\n"
                + "\t\tназвание группы: " + nameGroup + ",\n";
        }

        public void validate()
        {
            if (logicOperator == null || field == null || dictionField == null || value == null || nameGroup == null)
            {
                throw new ArgumentException("Значения в полях должны быть заполнены!");
            }
        }
    }
}
