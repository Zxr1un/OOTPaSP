using System;

namespace _5Laba.AWindows
{
    public interface IHandleLineEditWindow
    {
        double Left1 { get; set; }
        double Top1 { get; set; }
        IMainWindow Owner1 { get; set; }
        _5Laba_library.HandlePolygon ParentPolygon1 { get; set; }
        event Action<double, double, double, double> LineChanged;
        event Action<double, double, double, double> LineApplied;
        void Initialize(double Left, double Top, IMainWindow Owner, _5Laba_library.HandlePolygon ParentPolygon);
        void UpdateValues(double length, double angle, double x2, double y2);
        void Close();
        void Show();
        void Hide();
    }
}
