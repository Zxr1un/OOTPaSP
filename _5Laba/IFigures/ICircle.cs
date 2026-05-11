using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace _5Laba.IFigures
{
    internal interface ICircle
    {
        // Properties
        Ellipse cir { get; set; }
        double st_radius { get; set; }
        double e { get; set; }
        bool center_at_focus { get; set; }
        int stroke_thickness_cir { get; set; }
        System.Windows.Media.Brush stroke_cir { get; set; }
        Ellipse dop_center1 { get; set; }
        Ellipse dop_center2 { get; set; }

        // Methods (inherited from FigureMy)
        void base_init(bool reinitial = false);
        void Clone();
        void Insert();
        void Edit();
        void Draw();
        void Update_borders();
        void Delete();
        void Select();
        void Deselect();
        void Load(System.Text.Json.JsonElement el);
        void Save();
    }
}

