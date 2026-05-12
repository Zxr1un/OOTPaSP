using System.Windows;
using System.Windows.Shapes;

namespace _5Laba_InterfacesLibrary
{
    public interface IPolygonMy : IFigureMy
    {
        // Properties
        List<ISide> sides { get; set; }
        List<Point> points { get; set; }
        Polygon poly { get; set; }

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
        void Load(System.Text.Json.JsonElement el);
        void Save(IFigureMy fig, Dictionary<string, object> dict);
    }
}

