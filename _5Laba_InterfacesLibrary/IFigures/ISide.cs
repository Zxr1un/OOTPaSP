using System.Windows;
using System.Windows.Media;


namespace _5Laba_InterfacesLibrary
{
    public interface ISide: IPolygonMy
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
        void UpdatePoints(Point p1, Point p2, ISide prev = null, ISide next = null);
    }
}

