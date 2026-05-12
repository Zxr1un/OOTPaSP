using _5Laba_InterfacesLibrary;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace _5Laba_library
{
    public class FigureFactory: IFigureFactory
    {
        public IWindowsFactory WF { get; set; }
        public IFigureFactory FFref { get; set; }
        public ISE SEref { get; set; }
        public IFigureMy FromJson(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            return ParseFigure(doc.RootElement, null);
        }
        private IFigureMy ParseFigure(JsonElement el, IFigureMy parent)
        {
            string type = GetString(el, "type");

            IFigureMy fig = CreateByType(type);

            fig.parent = parent;

            // Стандартное
            fig.type = type;
            fig.name = GetString(el, "name");

            fig.glob = GetPoint(el, "glob");
            fig.center_loc = GetPoint(el, "center_loc");

            fig.scale = GetDouble(el, "scale", 1);
            fig.angle = GetDouble(el, "angle", 0);
            fig.dop_angle = GetDouble(el, "dop_angle", 0);

            string color = GetString(el, "color");
            if (!string.IsNullOrEmpty(color))
            {
                try
                {
                    fig.color = (Brush)new BrushConverter().ConvertFromString(color);
                }
                catch
                {
                    fig.color = Brushes.Transparent;
                }
            }
            fig.Load(el);

            if (el.TryGetProperty("children", out var children) &&
                children.ValueKind == JsonValueKind.Array)
            {
                foreach (var child in children.EnumerateArray())
                {
                    var ch = ParseFigure(child, fig);
                    fig.children.Add(ch);
                    ch.parent = fig;
                }
            }

            return fig;
        }
        private IFigureMy CreateByType(string type)
        {
            return type switch
            {
                "circle" => new Circle(FFref,SEref, WF),
                "polygon" => new PolygonMy(FFref, SEref, WF),
                "superfigure" => new SuperFigure(FFref, SEref, WF),
                "side" => new Side(FFref, SEref, WF, null, new(0,0), new(0,0)),
                "scene" => new Scene(FFref, SEref, WF),
                _ => new FigureMy(FFref, SEref, WF)
            };
        }

        public FigureFactory(IFigureFactory fFref, ISE sEref, IWindowsFactory wF)
        {
            FFref = this;
            SEref = sEref;
            WF = wF;
        }



        // Вспомогательное
        public string GetString(JsonElement el, string name)
        {
            return el.TryGetProperty(name, out var v)
                ? v.GetString()
                : null;
        }

        public double GetDouble(JsonElement el, string name, double def = 0)
        {
            return el.TryGetProperty(name, out var v)
                ? v.GetDouble()
                : def;
        }

        public Point GetPoint(JsonElement el, string name)
        {
            if (!el.TryGetProperty(name, out var v))
                return new Point(0, 0);

            double x = v.TryGetProperty("X", out var px) ? px.GetDouble() : 0;
            double y = v.TryGetProperty("Y", out var py) ? py.GetDouble() : 0;

            return new Point(x, y);
        }

        public string BrushToString(Brush brush)
        {
            if (brush is SolidColorBrush scb)
                return scb.Color.ToString();

            return "Transparent";
        }


        public IFigureMy Load(string json)
        {
            IFigureMy fig = FromJson(json);
            if(!(fig is Scene)) fig.Insert();
            return fig;
        }




        public void SaveToFile(IFigureMy root, string path)
        {
            var obj = SerializeFigure(root);

            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        private object SerializeFigure(IFigureMy fig)
        {
            var dict = new Dictionary<string, object>();

            dict["type"] = fig.type;
            dict["name"] = fig.name;

            dict["glob"] = new { fig.glob.X, fig.glob.Y };
            dict["center_loc"] = new { fig.center_loc.X, fig.center_loc.Y };

            dict["scale"] = fig.scale;
            dict["angle"] = fig.angle;
            dict["dop_angle"] = fig.dop_angle;

            dict["color"] = BrushToString(fig.color);

            // 🔥 ВАЖНО: специфичные поля
            FillCustomFields(fig, dict);

            // children
            var children = new List<object>();
            foreach (var ch in fig.children)
                children.Add(SerializeFigure(ch));

            dict["children"] = children;

            return dict;
        }

        private void FillCustomFields(IFigureMy fig, Dictionary<string, object> dict)
        {
            if (fig is Circle c)
            {
                c.Save(fig, dict);
                //dict["radius"] = c.st_radius;
                //dict["stroke_thickness_cir"] = c.stroke_thickness_cir;
                //dict["stroke_cir"] = BrushToString(c.stroke_cir);
                //dict["e"] = c.e;
            }

            if (fig is Side s)
            {
                s.Save(fig, dict);
                //dict["index"] = s.Index;

                //dict["glob_2"] = new { s.glob_2.X, s.glob_2.Y };

                //dict["thickness"] = s.thickness;
                //dict["color_s"] = BrushToString(s.color_s);
            }

            else if (fig is PolygonMy p)
            {
                p.Save(fig, dict);
                //dict["points"] = p.points;
            }

            

            if (fig is SuperFigure)
            {
                // пока пусто
            }
        }



        public IFigureMy newFM(string Name = "Фигура")
        {
            FigureMy fig = new FigureMy(FFref, SEref, WF, Name);
            fig.name = fig.SEref.Get_nomber() + "_" + Name;
            return fig;
        }
        public ICircle newC(string Name = "Эллипс")
        {
            Circle fig = new Circle(FFref, SEref, WF);
            fig.name = fig.SEref.Get_nomber() + "_" + Name;
            return fig;
        }
        public IHandlePolygon newHP(string Name = "Полилиния")
        {
            HandlePolygon fig = new HandlePolygon(FFref, SEref, WF);
            fig.name = fig.SEref.Get_nomber() + "_" + Name;
            return fig;
        }
        public IPolygonMy newP(int sides, string Name = "Многоугольник")
        {

            PolygonMy poly =
                new PolygonMy(FFref, SEref, WF);
            poly.name = poly.SEref.Get_nomber() + "_" + Name;
            poly.points.Clear();

            double side = 100;

            // Радиус описанной окружности
            double R =
                side / (2 * Math.Sin(Math.PI / sides));

            // Чтобы вершина была сверху
            double startAngle = -Math.PI / 2;

            for (int i = 0; i < sides; i++)
            {
                double angle =
                    startAngle + 2 * Math.PI * i / sides;

                double x = R * Math.Cos(angle);
                double y = R * Math.Sin(angle);

                poly.points.Add(new Point(x, y));
            }

            return poly;
        }
        public ISuperFigure newSF(string Name = "Объединение")
        {
            SuperFigure fig = new SuperFigure(FFref, SEref, WF);
            fig.name = fig.SEref.Get_nomber() + "_" + Name;
            return fig;
        }
        public ISide newSide(IPolygonMy par, Point p1, Point p2, string Name = "Сторона")
        {
            Side fig = new Side(FFref, SEref, WF, par, p1, p2);
            fig.name = "_" + Name;
            return fig;
        }
        public IScene newSC(string Name = "Сцена")
        {
            Scene fig = new Scene(FFref, SEref, WF);
            fig.name = "_" + Name;
            return fig;
        }

    }

}