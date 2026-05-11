using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _5Laba.IFigures.Polygons
{
    internal interface ISide
    {
        // Properties
        int Index { get; set; }
        Vector vector { get; set; }
        Point glob_2 { get; set; }
        Point T_P1 { get; set; }
        Point T_P2 { get; set; }
        Point H_P1 { get; set; }
        Point H_P2 { get; set; }
        Brush color_s { get; set; }
        int thickness { get; set; }

        // Methods
        void UpdatePoints(Point p1, Point p2);
    }
}

