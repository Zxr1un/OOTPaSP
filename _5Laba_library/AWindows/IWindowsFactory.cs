using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _5Laba_library
{
    public interface IWindowsFactory
    {
        IMainWindow new_MW();

        IRedWindow new_RW(FigureMy figure);

        IHandleLineEditWindow new_LEW(double Left, double Top, IMainWindow Owner, HandlePolygon ParentPolygon);
    }
}
