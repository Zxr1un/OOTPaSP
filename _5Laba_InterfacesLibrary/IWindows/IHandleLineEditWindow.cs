namespace _5Laba_InterfacesLibrary
{
    public interface IHandleLineEditWindow
    {
        double Left1 { get; set; }
        double Top1 { get; set; }
        IMainWindow Owner1 { get; set; }
        IHandlePolygon ParentPolygon1 { get; set; }
        event Action<double, double, double, double> LineChanged;
        event Action<double, double, double, double> LineApplied;
       // void Initialize(double Left, double Top, IMainWindow Owner, IHandlePolygon ParentPolygon);
        void UpdateValues(double length, double angle, double x2, double y2);
        void Close();
        void Show();
        void Hide();
    }
}
