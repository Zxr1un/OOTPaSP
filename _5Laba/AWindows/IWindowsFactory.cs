using System;

namespace _5Laba.AWindows
{
    public interface IWindowsFactory
    {
        IMainWindow new_MW();
        IRedWindow new_RW(_5Laba_library.FigureMy figure);
        IHandleLineEditWindow new_LEW(double Left, double Top, IMainWindow Owner, _5Laba_library.HandlePolygon ParentPolygon);
    }
}
