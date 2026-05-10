namespace _5Laba.Figures.Polygons
{
    public class Triangle: PolygonMy
    {
        public Triangle() {
            name = SE.Get_nomber() + "_" + "Треугольник";

            points.Add(new(-50, -28.87));
            points.Add(new(50, -28.87));
            points.Add(new(0, 57.74));

        }
    }
}
