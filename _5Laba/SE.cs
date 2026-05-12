using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using _5Laba_InterfacesLibrary;

namespace _5Laba
{
    public static class SE
    {
        public static ISE se = new SEref();
        public static IWindowsFactory wfc = new WFC();
        public static IFigureFactory FF;
    }
    //Static Elements
    public class SEref : ISE
    {
        public int counter { get; set; } = 0;
        public IMainWindow MW { get; set; }
        public Canvas canva { get; set; } = null;
        public List<IFigureMy> selected { get; set; } = new();
        public IScene Scene { get; set; }
        public  List<TreeView> HierarchyTreeColl { get; set; } = new();

        public List<IFigureMy> Saved { get; set; } = new();

        public void init()
        {
            counter = 0;
            selected = new();
            Scene = SE.FF.newSC();
            HierarchyTreeColl = new();
            Saved = new();
        }

        public Point Get_center()
        {
            double x = canva.ActualWidth / 2;
            double y = canva.ActualHeight / 2;
            return new Point(x, y);
        }

        public void Select(IFigureMy fig, bool isRepeat = false)
        {
            if (selected.Count != 0 && !Keyboard.IsKeyDown(Key.LeftShift) && !isRepeat)
            {
                foreach (IFigureMy f in selected) f.Deselect();
                selected.Clear();
                MW.SetUniteDisabled();
            }
            if (fig.parent != null)
            {
                if (fig.parent is IScene)
                {
                    if (selected.Contains(fig)) return;
                    if (fig is IScene) return;
                    selected.Add(fig);
                    fig.Select();
                }
                else
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl))
                    {
                        if (!isRepeat)
                        {
                            foreach (IFigureMy f in selected) f.Deselect();
                            selected.Clear();
                            MW.SetUniteDisabled();
                        }
                        if (fig is IScene) return;
                        selected.Add(fig);
                        fig.Select();
                        Select(fig.parent, true);
                    }
                    else
                    {
                        SE.se.Select(fig.parent);
                    }
                }

            }


            if (selected.Count > 1) MW.SetUniteEnabled();
        }
        public void DeselectAll()
        {
            foreach (IFigureMy f in selected) f.Deselect();
            selected.Clear();
        }
        public string Get_nomber()
        {
            counter++;
            return counter.ToString();
        }

        
        public void Register(TreeView Tree)
        {
            HierarchyTreeColl.Add(Tree);
            UpdateHierarchy();
        }
        public void UnRegister(TreeView Tree)
        {
            HierarchyTreeColl.Remove(Tree);
            UpdateHierarchy();
        }
        public void UpdateHierarchy()
        {
            foreach (TreeView HierarchyTree in HierarchyTreeColl)
            {
                if (HierarchyTree == null) return;
                // Если дерево пустое — создаём корень
                if (HierarchyTree.Items.Count == 0)
                {
                    TreeViewItem root = new TreeViewItem
                    {
                        Header = Scene.name,
                        Tag = Scene,
                        IsExpanded = true
                    };
                    HierarchyTree.Items.Add(root);
                }

                // Синхронизируем дерево с текущей сценой
                SyncTree((TreeViewItem)HierarchyTree.Items[0], Scene);
            }
            foreach (TreeView HierarchyTree in HierarchyTreeColl)
            {
                if (HierarchyTree == null) HierarchyTreeColl.Remove(HierarchyTree);
            }
        }
        private void SyncTree(TreeViewItem parentNode, IFigureMy sceneNode)
        {
            // 1️⃣ Удаляем узлы, которых больше нет в сцене
            for (int i = parentNode.Items.Count - 1; i >= 0; i--)
            {
                if (parentNode.Items[i] is TreeViewItem childTvi)
                {
                    if (childTvi.Tag is IFigureMy childFig)
                    {

                        if (!sceneNode.children.Any(c => c.Id == childFig.Id && c.name == childFig.name))
                        {
                            parentNode.Items.RemoveAt(i);
                        }
                        else
                        {
                            childTvi.Header = $"{childFig.name} ({childFig.GetType().Name})";
                            SyncTree(childTvi, childFig);
                        }
                    }
                }
            }

            // 2️⃣ Добавляем новые узлы
            foreach (var childFig in sceneNode.children)
            {
                bool exists = false;
                foreach (TreeViewItem tvi in parentNode.Items)
                {
                    if (tvi.Tag is IFigureMy existingFig && existingFig.Id == childFig.Id && existingFig.name == childFig.name)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    TreeViewItem newNode = new TreeViewItem
                    {
                        Header = $"{childFig.name} ({childFig.GetType().Name})",
                        Tag = childFig
                    };
                    parentNode.Items.Add(newNode);

                    // рекурсивно добавляем поддерево
                    SyncTree(newNode, childFig);
                }
            }
        }
        public TreeViewItem CreateNode(IFigureMy fig)
        {
            TreeViewItem node = new TreeViewItem
            {
                Header = $"{fig.name} ({fig.GetType().Name})",
                Tag = fig
            };
            foreach (var child in fig.children)
            {
                node.Items.Add(CreateNode(child));
            }
            return node;
        }

        public void SaveFigure(IFigureMy fig)
        {
            Saved.Add(fig.Clone());
            UpdateSavedMenu();
        }
        public void LoadFigure(IFigureMy fig)
        {
            IFigureMy fig1 = fig.Clone();
            fig1.Insert();
        }

        public void UpdateSavedMenu()
        {
            if (MW == null || MW.GetSavedMenu() == null) return;

            MW.GetSavedMenu().Items.Clear();

            foreach (var fig in Saved.ToList())
            {
                MenuItem figItem = new MenuItem
                {
                    Header = $"{fig.name} ({fig.GetType().Name})"
                };

                //Добавить
                MenuItem addItem = new MenuItem
                {
                    Header = "Добавить"
                };
                addItem.Click += (s, e) =>
                {
                    LoadFigure(fig);
                };

                MenuItem SaveItem = new MenuItem
                {
                    Header = "Сохранить в файл"
                };
                SaveItem.Click += (s, e) =>
                {
                    var dialog = new SaveFileDialog
                    {
                        Title = "Сохранить фигуру/сцену",
                        Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                        DefaultExt = "json",
                        FileName = "figure.json"
                    };

                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        string path = dialog.FileName;

                        SE.FF.SaveToFile(fig, path);
                    }
                };

                //Удалить
                MenuItem deleteItem = new MenuItem
                {
                    Header = "Удалить"
                };
                deleteItem.Click += (s, e) =>
                {
                    Saved.Remove(fig);
                    UpdateSavedMenu();
                };

                figItem.Items.Add(addItem);
                figItem.Items.Add(SaveItem);
                figItem.Items.Add(deleteItem);

                MW.GetSavedMenu().Items.Add(figItem);
            }
        }
    }

}
