using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba.IFigures.Polygons
{
    /// <summary>
    /// Реализация интерфейса ISide на основе класса Side из библиотеки
    /// </summary>
    internal class SideImpl : ISide
    {
        private Side _side;

        public SideImpl(Side side)
        {
            _side = side ?? throw new ArgumentNullException(nameof(side));
        }

        public int Index
        {
            get => _side.Index;
            set => _side.Index = value;
        }

        public System.Windows.Vector vector
        {
            get => _side.vector;
            set => _side.vector = value;
        }

        public System.Windows.Point glob_2
        {
            get => _side.glob_2;
            set => _side.glob_2 = value;
        }

        public System.Windows.Point T_P1
        {
            get => _side.T_P1;
            set => _side.T_P1 = value;
        }

        public System.Windows.Point T_P2
        {
            get => _side.T_P2;
            set => _side.T_P2 = value;
        }

        public System.Windows.Point H_P1
        {
            get => _side.H_P1;
            set => _side.H_P1 = value;
        }

        public System.Windows.Point H_P2
        {
            get => _side.H_P2;
            set => _side.H_P2 = value;
        }

        public System.Windows.Media.Brush color_s
        {
            get => _side.color_s;
            set => _side.color_s = value;
        }

        public int thickness
        {
            get => _side.thickness;
            set => _side.thickness = value;
        }

        public void UpdatePoints(System.Windows.Point p1, System.Windows.Point p2) => _side.UpdatePoints(p1, p2);
    }
}
