using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _5Laba_InterfacesLibrary
{
    public interface IFigureMy
    {
        IWindowsFactory WF { get; set; }
        IFigureFactory FFref { get; set; }
        ISE SEref { get; set; }
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
        Ellipse CenterPoint { get; set; }
        IFigureMy parent { get; set; }
        ObservableCollection<IFigureMy> children { get; set; }
        IRedWindow RW { get; set; }
        bool dropping { get; set; }
        Point shapeStartPosition { get; set; }
        Point lastMousePosition { get; set; }

        // Methods
        void base_init(bool reinitial = false);
        IFigureMy Clone(IFigureMy part = null, IFigureMy parentCop = null);
        void Insert(IFigureMy par = null);
        void Edit();
        void Draw();
        void Update_borders();
        void Delete();
        void Select();
        void Deselect();
        void Load(JsonElement el);
        void Save(IFigureMy fig, Dictionary<string, object> dict);
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

