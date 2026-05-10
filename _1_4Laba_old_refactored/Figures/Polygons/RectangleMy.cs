namespace _5Laba.Figures.Polygons
{
    public class RectangleMy: PolygonMy
    {
        public RectangleMy() {
            name = SE.Get_nomber() + "_" + "Прямоугольник";

            points.Add(new(-50, -50));
            points.Add(new(-50, 50));
            points.Add(new(50, 50));
            points.Add(new(50, -50));

        }
    }
}
