using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace _5Laba.IFigures
{
    internal interface IPolygonMy
    {
        // Properties
        List<object> sides { get; set; } // List<Side> представлен как List<object>
        List<Point> points { get; set; }
        Polygon poly { get; set; }

        // Methods
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

