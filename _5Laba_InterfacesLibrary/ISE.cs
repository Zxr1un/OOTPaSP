
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics.Metrics;

namespace _5Laba_InterfacesLibrary
{
    public interface ISE
    {
        int counter { get; set; } //= 0;
        IMainWindow MW { get; set; }
        Canvas canva { get; set; } //= null;
        List<IFigureMy> selected { get; set; } //= new();
        IScene Scene {  get; set; }
        List<TreeView> HierarchyTreeColl { get; set; } //= new();

        List<IFigureMy> Saved { get; set; } //= new();

        void init();

        Point Get_center();

        void Select(IFigureMy fig, bool isRepeat = false);
        void DeselectAll();

        string Get_nomber();



        void Register(TreeView Tree);

        void UnRegister(TreeView Tree);

        void UpdateHierarchy();

        TreeViewItem CreateNode(IFigureMy fig);

        void SaveFigure(IFigureMy fig);
        void LoadFigure(IFigureMy fig);

        void UpdateSavedMenu();
    }
}
