using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _5Laba_InterfacesLibrary
{
    public interface IHandlePolygon: IFigureMy
    {
        // Properties
        double dop_angle { get; set; }
        double angle_cur { get; set; }

        // Methods
        void Start();
        void Canvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e);
        public void FinishPolygonWithSpace();
    }
}

