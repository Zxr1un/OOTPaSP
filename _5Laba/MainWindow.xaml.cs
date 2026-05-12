using _5Laba_InterfacesLibrary;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection;

namespace _5Laba
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SE.se = new SEref();
            SE.se.MW = this;
            SE.se.canva = Canva;

            string path = "d:\\Zaxar_sd\\_BSUIR_Study\\__2\\OOTaSP\\5laba\\_5Laba_library\\bin\\Debug\\net8.0-windows\\_5Laba_library.dll";
            Assembly asm = Assembly.LoadFrom(path);
            Type factoryType = asm.GetTypes()
            .First(t =>
               typeof(IFigureFactory)
               .IsAssignableFrom(t)
               && !t.IsInterface
               && !t.IsAbstract);

            SE.FF =
                (IFigureFactory)
                Activator.CreateInstance(
                    factoryType,
                    null,
                    SE.se,
                    new WFC()
                );
            
            SE.se.init();
            SE.wfc = new WFC();
            SE.se.Register(HierarchyTree);
            HierarchyTree.MouseDoubleClick += HierarchyTree_MouseDoubleClick;
            this.WindowState = WindowState.Maximized;
            

        }


        private void CreateCircle_Click(object sender, RoutedEventArgs e)
        {
            ICircle cir = SE.FF.newC();
            cir.base_init();
        }

        private void CreateTriangle_Click(object sender, RoutedEventArgs e)
        {
            IPolygonMy p = SE.FF.newP(3);
            p.base_init();
        }

        private void CreateSquare_Click(object sender, RoutedEventArgs e)
        {
            IPolygonMy p = SE.FF.newP(4);
            p.base_init();
        }

        private void CreatePolygon_Click(object sender, RoutedEventArgs e)
        {
            IHandlePolygon hp = SE.FF.newHP();
            hp.Start();
        }
        private void ClearScene_Click(object sender, RoutedEventArgs e)
        {
            SE.se.Scene.Delete();
            SE.se.UpdateHierarchy();
        }
        private void CreateTrapezioid_Click_Click(object sender, RoutedEventArgs e)
        {
            IPolygonMy p = SE.FF.newP(4);
            p.name = SE.se.Get_nomber() + "_" + "Трапеция";
            p.points.Clear();
            p.points.Add(new(-50, -50));
            p.points.Add(new(-25, 50));
            p.points.Add(new(25, 50));
            p.points.Add(new(50, -50));
            p.base_init();
        }

        private void CreatePentagon_Click(object sender, RoutedEventArgs e)
        {
            IPolygonMy p = SE.FF.newP(5);
            p.base_init();
        }



        private void HierarchyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (HierarchyTree.SelectedItem is TreeViewItem item &&
                item.Tag is IFigureMy fig)
            {
                SE.se.Select(fig);
            }
        }

        private void HierarchyTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (HierarchyTree.SelectedItem is TreeViewItem item)
            {
                if (item.Tag is IFigureMy fig)
                {
                    fig.Edit();
                }
            }
        }

        public MenuItem GetSavedMenu()
        {
            return SavedMenu;
        }

        private void Unite_Click(object sender, RoutedEventArgs e)
        {
            if(SE.se.selected.Count > 1)
            {
                ISuperFigure SF = SE.FF.newSF();
                SF.base_init();
                List<IFigureMy> copyList = SE.se.selected.ToList();
                for (int i = copyList.Count - 1; i >= 0; i--)
                {
                    for (int j = copyList.Count - 1; j >= 0; j--)
                    {
                        if (i != j && copyList[i].children.Contains(copyList[j]))
                        {
                            copyList.RemoveAt(j);
                        }
                    }
                }
                if (copyList.Count < 2)
                {
                    SF.Delete();
                    return;
                }

                foreach (IFigureMy s in copyList)
                {
                    SF.AddFigure(s);
                }
                SE.se.DeselectAll();
                SE.se.Select(SF);
                
            }
        }

        public void SetUniteEnabled()
        {
            Unite.IsEnabled = SE.se.selected.Count > 1;
        }
        public void SetUniteDisabled()
        {
            Unite.IsEnabled = false;
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.OriginalSource == Canva)
            {
                SE.se.DeselectAll();
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        // Чтобы окно перетаскивалось за меню:
        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void importFigure_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Импорт фигуры / сцены",
                Filter = "Scene files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;

                string json = System.IO.File.ReadAllText(path);

                IFigureMy fig = SE.FF.Load(json);
                if(fig is IScene AF)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show(
                        "В файле была обнаружена сцена, загрузить её? (все не сохранённые изменения будут потеряны)",
                        "Загрузка сцены",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        SE.se.Scene.Delete();
                        SE.se.Scene = AF;
                        SE.se.Scene.Insert();
                    }
                }
                else SE.se.SaveFigure(fig);
            }
        }

        private void SaveScene_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Сохранить сцену",
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                FileName = "scene.json"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string path = dialog.FileName;

                SE.FF.SaveToFile(SE.se.Scene, path);
            }
        }
        //не использую
        private void LoadScene_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}