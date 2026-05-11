using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace _5Laba.IFigures
{
    /// <summary>
    /// Реализация интерфейса ICircle на основе класса Circle из библиотеки
    /// </summary>
    internal class CircleImpl : ICircle
    {
        private Circle _circle;

        public CircleImpl() : this(new Circle()) { }

        public CircleImpl(Circle circle)
        {
            _circle = circle ?? throw new ArgumentNullException(nameof(circle));
        }

        public Ellipse cir
        {
            get => _circle.cir;
            set => _circle.cir = value;
        }

        public double st_radius
        {
            get => _circle.st_radius;
            set => _circle.st_radius = value;
        }

        public double e
        {
            get => _circle.e;
            set => _circle.e = value;
        }

        public bool center_at_focus
        {
            get => _circle.center_at_focus;
            set => _circle.center_at_focus = value;
        }

        public int stroke_thickness_cir
        {
            get => _circle.stroke_thickness_cir;
            set => _circle.stroke_thickness_cir = value;
        }

        public System.Windows.Media.Brush stroke_cir
        {
            get => _circle.stroke_cir;
            set => _circle.stroke_cir = value;
        }

        public Ellipse dop_center1
        {
            get => _circle.dop_center1;
            set => _circle.dop_center1 = value;
        }

        public Ellipse dop_center2
        {
            get => _circle.dop_center2;
            set => _circle.dop_center2 = value;
        }

        public void base_init(bool reinitial = false) => _circle.base_init(reinitial);

        public void Clone() => _circle.Clone();

        public void Insert() => _circle.Insert();

        public void Edit() => _circle.Edit();

        public void Draw() => _circle.Draw();

        public void Update_borders() => _circle.Update_borders();

        public void Delete() => _circle.Delete();

        public void Select() => _circle.Select();

        public void Deselect() => _circle.Deselect();

        public void Load(JsonElement el) => _circle.Load(el);

        public void Save() => _circle.Save(_circle, new Dictionary<string, object>());
    }
}
