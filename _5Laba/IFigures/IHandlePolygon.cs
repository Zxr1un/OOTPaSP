using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba.IFigures
{
    internal interface IHandlePolygon
    {
        // Properties
        double dop_angle { get; set; }
        double angle_cur { get; set; }

        // Methods
        void Start();
        void Canvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e);
    }
}

