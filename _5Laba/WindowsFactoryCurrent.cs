using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5Laba_library;

namespace _5Laba
{
    internal class WindowsFactoryCurrent: IWindowsFactory
    {
        public IMainWindow new_MW()
        {
            return new MainWindow();
        }

        public IRedWindow new_RW(FigureMy figure)
        {
            return new RedWindow(figure);
        }

        public IHandleLineEditWindow new_LEW(double Left, double Top, IMainWindow Owner, HandlePolygon ParentPolygon)
        {
            return new HandleLineEditWindow() { Left1 = Left, Top1 = Top, Owner1 = Owner, ParentPolygon1 = ParentPolygon };
        }
    }
}
