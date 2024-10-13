using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    internal class IndexPalitre
    {
        private Color[] palitre = new Color[] { Color.Red, Color.Violet, Color.Orange, Color.Blue, Color.Green };
        private int currentIndexColor;

        public Color getColor()
        {
            if (currentIndexColor < palitre.Length)
            {
                currentIndexColor++;
                return palitre[currentIndexColor - 1];
            } else
            {
                currentIndexColor = 0;
                return palitre[currentIndexColor];
            }
        }
    }
}
