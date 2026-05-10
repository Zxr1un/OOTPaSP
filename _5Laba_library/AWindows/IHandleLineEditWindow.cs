using System.Drawing;


namespace _5Laba_library
{
    public interface IHandleLineEditWindow
    {
        public double Left1 { get; set; }
        public double Top1 { get; set; }
        public IMainWindow Owner1 { get; set; }
        public HandlePolygon ParentPolygon1 { get; set; }

        public event Action<double, double, double, double> LineChanged;
        public event Action<double, double, double, double> LineApplied;

        

        public void Initialize(double Left, double Top, IMainWindow Owner, HandlePolygon ParentPolygon)
        {
            this.Left1 = Left;
            this.Top1 = Top;
            this.Owner1 = Owner;
            this.ParentPolygon1 = ParentPolygon;
        }

        public void UpdateValues(double length, double angle, double x2, double y2)
        {

        }
        public void Close()
        {

        }
        public void Show()
        {

        }
        public void Hide()
        {

        }
    }
}
