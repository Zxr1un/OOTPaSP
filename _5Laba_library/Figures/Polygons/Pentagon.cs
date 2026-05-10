
namespace _5Laba_library
{
    public class Pentagon: PolygonMy
    {
        public Pentagon()
        {
            name = SE.Get_nomber() + "_" + "Пятиугольник";

            points.Add(new(0, -85.065));
            points.Add(new(80.90, -26.30));
            points.Add(new(50, 68.82));
            points.Add(new(-50, 68.82));
            points.Add(new(-80.9, -26.3));

        }
    }
}
