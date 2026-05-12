using System;

namespace _5Laba_InterfacesLibrary
{
    public interface IWindowsFactory
    {
        IMainWindow new_MW();
        IRedWindow new_RW(IFigureMy figure);
        IHandleLineEditWindow new_LEW(double Left, double Top, IMainWindow Owner, IHandlePolygon ParentPolygon);
    }
}
