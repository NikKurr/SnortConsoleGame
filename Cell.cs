using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snort
{
    public class Cell
    {
        public ColorOfCell ColorOfCell { get; private set; }
        
        public void SetNewColorCell(ColorOfCell cellColor)
        {
            if(ColorOfCell == ColorOfCell.empty)
                ColorOfCell = cellColor;//only if empty than we need to change our color
        }
        public Cell(ColorOfCell color)
        {
            ColorOfCell = color;
        }

        public Cell(Cell other)
        {
            ColorOfCell = other.ColorOfCell;   // тут копіюється саме значення (enum), не посилання
        }
    }

    public enum ColorOfCell
    {
        empty,
        red,
        blue,
        notInUse
    }
}
