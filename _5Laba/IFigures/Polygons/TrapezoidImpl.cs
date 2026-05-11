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
    /// Реализация интерфейса ITrapezoid на основе класса Trapezoid из библиотеки
    /// </summary>
    internal class TrapezoidImpl : ITrapezoid
    {
        private Trapezoid _trapezoid;

        public TrapezoidImpl() : this(new Trapezoid()) { }

        public TrapezoidImpl(Trapezoid trapezoid)
        {
            _trapezoid = trapezoid ?? throw new ArgumentNullException(nameof(trapezoid));
        }

        public List<object> sides
        {
            get => _trapezoid.sides.ConvertAll(s => (object)s);
            set => _trapezoid.sides = new List<Side>(value.OfType<Side>());
        }

        public List<System.Windows.Point> points
        {
            get => _trapezoid.points;
            set => _trapezoid.points = value;
        }

        public System.Windows.Shapes.Polygon poly
        {
            get => _trapezoid.poly;
            set => _trapezoid.poly = value;
        }

        public void base_init(bool reinitial = false) => _trapezoid.base_init(reinitial);
        public void Clone() => _trapezoid.Clone();
        public void Insert() => _trapezoid.Insert();
        public void Edit() => _trapezoid.Edit();
        public void Draw() => _trapezoid.Draw();
        public void Update_borders() => _trapezoid.Update_borders();
        public void Delete() => _trapezoid.Delete();
        public void Select() => _trapezoid.Select();
        public void Deselect() => _trapezoid.Deselect();
        public void Load(JsonElement el) => _trapezoid.Load(el);
        public void Save() => _trapezoid.Save(_trapezoid, new Dictionary<string, object>());
    }
}
