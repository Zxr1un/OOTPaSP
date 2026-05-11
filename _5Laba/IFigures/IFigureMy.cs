using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _5Laba.IFigures
{
    public interface IFigureMy
    {
        // Properties
        Guid Id { get; set; }
        Canvas canva { get; set; }
        string type { get; set; }
        Point glob { get; set; }
        Brush color { get; set; }
        Point center_loc { get; set; }
        double scale { get; set; }
        double angle { get; set; }
        double dop_angle { get; set; }
        string name { get; set; }
        Point b_p1 { get; set; }
        Point b_p2 { get; set; }
        Rectangle border { get; set; }
        System.Windows.Shapes.Ellipse CenterPoint { get; set; }
        FigureMy parent { get; set; }
        ObservableCollection<FigureMy> children { get; set; }
        IRedWindow RW { get; set; }
        bool dropping { get; set; }
        Point shapeStartPosition { get; set; }
        Point lastMousePosition { get; set; }

        // Circle-specific properties
        double st_radius { get; set; }
        double e { get; set; }
        int stroke_thickness_cir { get; set; }
        Brush stroke_cir { get; set; }
        bool center_at_focus { get; set; }

        // Methods
        void base_init(bool reinitial = false);
        FigureMy Clone(FigureMy part = null, FigureMy parentCop = null);
        void Insert(FigureMy par = null);
        void Edit();
        void Draw();
        void Update_borders();
        void Delete();
        void Select();
        void Deselect();
        void Load(JsonElement el);
        void Save(FigureMy fig, Dictionary<string, object> dict);
        void Move(double x, double y);
        void Move();
        void d_Move(double dx, double dy);
        void d_Move_drag(double dx, double dy);
        void setScale(double new_scale);
        void Rejection();
        Point getGlobal(Point p);
        Point getLocal(Point p);
    }
}

