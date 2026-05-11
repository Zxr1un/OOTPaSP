using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _5Laba.IFigures.Polygons
{
    /// <summary>
    /// Реализация интерфейса ITriangle на основе класса Triangle из библиотеки
    /// </summary>
    internal class TriangleImpl : ITriangle
    {
        private Triangle _triangle;

        public TriangleImpl() : this(new Triangle()) { }

        public TriangleImpl(Triangle triangle)
        {
            _triangle = triangle ?? throw new ArgumentNullException(nameof(triangle));
        }

        public List<object> sides
        {
            get => _triangle.sides.ConvertAll(s => (object)s);
            set => _triangle.sides = new List<Side>(value.OfType<Side>());
        }

        public List<System.Windows.Point> points
        {
            get => _triangle.points;
            set => _triangle.points = value;
        }

        public System.Windows.Shapes.Polygon poly
        {
            get => _triangle.poly;
            set => _triangle.poly = value;
        }

        public void base_init(bool reinitial = false) => _triangle.base_init(reinitial);
        public void Clone() => _triangle.Clone();
        public void Insert() => _triangle.Insert();
        public void Edit() => _triangle.Edit();
        public void Draw() => _triangle.Draw();
        public void Update_borders() => _triangle.Update_borders();
        public void Delete() => _triangle.Delete();
        public void Select() => _triangle.Select();
        public void Deselect() => _triangle.Deselect();
        public void Load(JsonElement el) => _triangle.Load(el);
        public void Save() => _triangle.Save(_triangle, new Dictionary<string, object>());
    }
}
