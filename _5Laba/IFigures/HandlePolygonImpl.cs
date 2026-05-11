using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _5Laba.IFigures
{
    /// <summary>
    /// Реализация интерфейса IHandlePolygon на основе класса HandlePolygon из библиотеки
    /// </summary>
    internal class HandlePolygonImpl : IHandlePolygon
    {
        private HandlePolygon _handlePolygon;

        public HandlePolygonImpl() : this(new HandlePolygon()) { }

        public HandlePolygonImpl(HandlePolygon handlePolygon)
        {
            _handlePolygon = handlePolygon ?? throw new ArgumentNullException(nameof(handlePolygon));
        }

        public double dop_angle
        {
            get => _handlePolygon.dop_angle;
            set => _handlePolygon.dop_angle = value;
        }

        public double angle_cur
        {
            get => _handlePolygon.angle_cur;
            set => _handlePolygon.angle_cur = value;
        }

        public void Start() => _handlePolygon.Start();

        public void Canvas_KeyDown(object sender, KeyEventArgs e) => _handlePolygon.Canvas_KeyDown(sender, e);
    }
}
