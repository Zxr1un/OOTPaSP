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
    /// Реализация интерфейса IPentagon на основе класса Pentagon из библиотеки
    /// </summary>
    internal class PentagonImpl : IPentagon
    {
        private Pentagon _pentagon;

        public PentagonImpl() : this(new Pentagon()) { }

        public PentagonImpl(Pentagon pentagon)
        {
            _pentagon = pentagon ?? throw new ArgumentNullException(nameof(pentagon));
        }

        public List<object> sides
        {
            get => _pentagon.sides.ConvertAll(s => (object)s);
            set => _pentagon.sides = new List<Side>(value.OfType<Side>());
        }

        public List<System.Windows.Point> points
        {
            get => _pentagon.points;
            set => _pentagon.points = value;
        }

        public System.Windows.Shapes.Polygon poly
        {
            get => _pentagon.poly;
            set => _pentagon.poly = value;
        }

        public void base_init(bool reinitial = false) => _pentagon.base_init(reinitial);
        public void Clone() => _pentagon.Clone();
        public void Insert() => _pentagon.Insert();
        public void Edit() => _pentagon.Edit();
        public void Draw() => _pentagon.Draw();
        public void Update_borders() => _pentagon.Update_borders();
        public void Delete() => _pentagon.Delete();
        public void Select() => _pentagon.Select();
        public void Deselect() => _pentagon.Deselect();
        public void Load(JsonElement el) => _pentagon.Load(el);
        public void Save() => _pentagon.Save(_pentagon, new Dictionary<string, object>());
    }
}
