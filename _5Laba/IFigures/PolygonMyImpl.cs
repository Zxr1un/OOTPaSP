using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace _5Laba.IFigures
{
    /// <summary>
    /// Реализация интерфейса IPolygonMy на основе класса PolygonMy из библиотеки
    /// </summary>
    internal class PolygonMyImpl : IPolygonMy
    {
        private PolygonMy _polygon;

        public PolygonMyImpl() : this(new PolygonMy()) { }

        public PolygonMyImpl(PolygonMy polygon)
        {
            _polygon = polygon ?? throw new ArgumentNullException(nameof(polygon));
        }

        public List<object> sides
        {
            get => _polygon.sides.ConvertAll(s => (object)s);
            set => _polygon.sides = new List<Side>(value.OfType<Side>());
        }

        public List<Point> points
        {
            get => _polygon.points;
            set => _polygon.points = value;
        }

        public Polygon poly
        {
            get => _polygon.poly;
            set => _polygon.poly = value;
        }

        public void base_init(bool reinitial = false) => _polygon.base_init(reinitial);

        public void Clone() => _polygon.Clone();

        public void Insert() => _polygon.Insert();

        public void Edit() => _polygon.Edit();

        public void Draw() => _polygon.Draw();

        public void Update_borders() => _polygon.Update_borders();

        public void Delete() => _polygon.Delete();

        public void Select() => _polygon.Select();

        public void Deselect() => _polygon.Deselect();

        public void Load(JsonElement el) => _polygon.Load(el);

        public void Save() => _polygon.Save(_polygon, new Dictionary<string, object>());
    }
}
