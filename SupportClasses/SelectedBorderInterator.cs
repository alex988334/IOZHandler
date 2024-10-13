using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuluLib;

namespace Example2.SupportClasses
{
    internal class SelectedBorderInterator : BorderInterator
    {
        protected int[] selectedBorderObjects = new int[] { };

        public SelectedBorderInterator(Layer layer, int[] selectedBorderObjects) : base(layer)
        {
            this.selectedBorderObjects = selectedBorderObjects;

            while (!selectedBorderObjects.Contains(int.Parse(rezult.DataSet.FieldValue[0])) && rezult.DataSet.MoveNext()) { }
        }

        override public bool moveNext()
        {
            while (rezult.DataSet.MoveNext())
            {
                if (selectedBorderObjects.Contains(int.Parse(rezult.DataSet.FieldValue[0])))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
