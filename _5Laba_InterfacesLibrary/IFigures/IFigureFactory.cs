using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace _5Laba_InterfacesLibrary
{
    public interface IFigureFactory
    {
        IWindowsFactory WF { get; set; }
        IFigureFactory FFref { get; set; }
        ISE SEref { get; set; }
        // Methods
        IFigureMy FromJson(string json);


        // Вспомогательное
        string GetString(JsonElement el, string name);

        double GetDouble(JsonElement el, string name, double def = 0);

        Point GetPoint(JsonElement el, string name);

        string BrushToString(Brush brush);
        IFigureMy Load(string json);
        void SaveToFile(IFigureMy root, string path);



        IFigureMy newFM(string Name = "Фигура");
        ICircle newC(string Name = "Эллипс");
        IHandlePolygon newHP(string Name = "Полилиния");
        IPolygonMy newP(int count = 0, string Name = "Многоугольник");
        ISuperFigure newSF(string Name = "Объединение");

        IScene newSC(string Name = "Сцена");

    }
}

