using System.Windows.Documents;
using System.Windows.Shapes;

namespace _5Laba_InterfacesLibrary
{
    public interface ICircle: IFigureMy
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
        IFigureMy Clone(IFigureMy part = null, IFigureMy parentCop = null);
        void Insert(IFigureMy par = null);
        void Edit();
        void Draw();
        void Update_borders();
        void Delete();
        void Select();
        void Deselect();
        void Load(System.Text.Json.JsonElement el);
        void Save(IFigureMy fig, Dictionary<string, object> dict);
    }
}

