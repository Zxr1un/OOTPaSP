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
    /// Реализация интерфейса IRectangleMy на основе класса RectangleMy из библиотеки
    /// </summary>
    internal class RectangleMyImpl : IRectangleMy
    {
        private RectangleMy _rectangle;

        public RectangleMyImpl() : this(new RectangleMy()) { }

        public RectangleMyImpl(RectangleMy rectangle)
        {
            _rectangle = rectangle ?? throw new ArgumentNullException(nameof(rectangle));
        }

        public List<object> sides
        {
            get => _rectangle.sides.ConvertAll(s => (object)s);
            set => _rectangle.sides = new List<Side>(value.OfType<Side>());
        }

        public List<System.Windows.Point> points
        {
            get => _rectangle.points;
            set => _rectangle.points = value;
        }

        public System.Windows.Shapes.Polygon poly
        {
            get => _rectangle.poly;
            set => _rectangle.poly = value;
        }

        public void base_init(bool reinitial = false) => _rectangle.base_init(reinitial);
        public void Clone() => _rectangle.Clone();
        public void Insert() => _rectangle.Insert();
        public void Edit() => _rectangle.Edit();
        public void Draw() => _rectangle.Draw();
        public void Update_borders() => _rectangle.Update_borders();
        public void Delete() => _rectangle.Delete();
        public void Select() => _rectangle.Select();
        public void Deselect() => _rectangle.Deselect();
        public void Load(JsonElement el) => _rectangle.Load(el);
        public void Save() => _rectangle.Save(_rectangle, new Dictionary<string, object>());
    }
}
