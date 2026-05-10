namespace _5Laba.Figures.Polygons
{
    public class Trapezoid: PolygonMy
    {
        public Trapezoid() {
            name = SE.Get_nomber() + "_" + "Трапеция";
            points.Add(new(-50, -50));
            points.Add(new(-25, 50));
            points.Add(new(25, 50));
            points.Add(new(50, -50));

        }
    }
}
