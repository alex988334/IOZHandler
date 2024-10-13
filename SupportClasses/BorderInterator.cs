using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuluLib;

namespace Example2.SupportClasses
{
    internal class BorderInterator : RootClass
    {
        protected Layer layer;
        protected IZSqlResult rezult;

        public BorderInterator(Layer layer)
        {
            this.layer = layer;

            rezult = layer.ExecSQL("SELECT Sys, Territory_list FROM [" + layer.UserName + "] ORDER BY Territory_list");
            if (rezult.RetCode != 0)
            {
                throw new ExceptionSQL("Ошибка выполнения SQL: " + rezult.ErrorString);
            }

            if (!rezult.DataSet.MoveFirst())
            {
                throw new Exception("ППТ слой с границами зон пустой! Выполнение прекращено");
            }
        }

        public int getCurrentZone()
        {
            return int.Parse(rezult.DataSet.FieldValue[0]);
        }

        virtual public bool moveNext()
        {
            return rezult.DataSet.MoveNext();
        }

        public string getNameCurrentZone()
        {
            return rezult.DataSet.FieldValue[1];
        }
    }
}
