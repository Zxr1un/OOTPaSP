using _5Laba_InterfacesLibrary;

namespace _5Laba
{
    //WindowsFactoryCurrent
    public class WFC: IWindowsFactory
    {
        public IMainWindow new_MW()
        {
            return new MainWindow();
        }

        public IRedWindow new_RW(IFigureMy figure)
        {
            return new RedWindow(figure);
        }

        public IHandleLineEditWindow new_LEW(double Left, double Top, IMainWindow Owner, IHandlePolygon ParentPolygon)
        {
            return new HandleLineEditWindow() { Left1 = Left, Top1 = Top, Owner1 = Owner, ParentPolygon1 = ParentPolygon };
        }
    }
}
