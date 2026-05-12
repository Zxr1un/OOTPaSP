using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using _5Laba_InterfacesLibrary;



namespace _5Laba_library
{
    public class FigureMy: IFigureMy
    {
        public IWindowsFactory WF { get; set; }
        public IFigureFactory FFref { get; set; }
        public ISE SEref { get; set; }



        public Guid Id { get; set; } = Guid.NewGuid();
        public Canvas canva { get; set; } = null;
        public string type { get; set; } = "figure";
        public Point glob { get; set; } = new Point(0, 0);
        public Brush color { get; set; } = Brushes.Transparent;

        public Point center_loc { get; set; } = new Point(0, 0);
        public double scale { get; set; } = 1;
        public double angle { get; set; } = 0;
        public double dop_angle { get; set; } = 0;
        public string name { get; set; } = "Figure";

        public Point b_p1 { get; set; } = new(0, 0);
        public Point b_p2 { get; set; } = new(0, 0);
        public Rectangle border { get; set; } = new Rectangle()
        {
            Visibility = Visibility.Hidden,
            StrokeThickness = 2,
            Stroke = Brushes.Gray,
            Fill = Brushes.Transparent,
            IsHitTestVisible = false
        };
        public Ellipse CenterPoint { get; set; } = new Ellipse()
        {
            Fill = Brushes.White,
            StrokeThickness = 2,
            Stroke = Brushes.Red,
            Width = 10,
            Height = 10,
            Visibility = Visibility.Hidden,
            IsHitTestVisible = false
        };

        public IFigureMy parent { get; set; } = null;
        public ObservableCollection<IFigureMy> children { get; set; } = new();

        public IRedWindow RW { get; set; } = null;
        public bool dropping { get; set; } = false;
        public Point shapeStartPosition { get; set; }
        public Point lastMousePosition { get; set; }

        public virtual IFigureMy Clone(IFigureMy part = null, IFigureMy parentCop = null)
        {
            IFigureMy copy;
            if (part == null) copy = FFref.newFM();
            else copy = part;
            copy.type = type;
            copy.glob = new(glob.X, glob.Y);
            copy.color = color;
            copy.center_loc = new(center_loc.X, center_loc.Y);
            copy.scale = scale;
            copy.angle = angle;
            copy.name = name;
            copy.b_p1 = new(b_p1.X, b_p1.Y);
            copy.b_p2 = new(b_p2.X, b_p2.Y);

            copy.border.Visibility = border.Visibility;
            copy.border.StrokeThickness = border.StrokeThickness;
            copy.border.Stroke = border.Stroke;
            copy.border.Fill = border.Fill;
            copy.border.IsHitTestVisible = border.IsHitTestVisible;


            copy.CenterPoint.Fill = CenterPoint.Fill;
            copy.CenterPoint.StrokeThickness = CenterPoint.StrokeThickness;
            copy.CenterPoint.Stroke = CenterPoint.Stroke;
            copy.CenterPoint.Width = CenterPoint.Width;
            copy.CenterPoint.Height = CenterPoint.Height;
            copy.CenterPoint.Visibility = CenterPoint.Visibility;
            copy.CenterPoint.IsHitTestVisible = CenterPoint.IsHitTestVisible;

            copy.parent = parentCop;
            foreach (IFigureMy ch in children)
            {
                IFigureMy copyCh = ch.Clone(null, copy);
                if (!(copyCh is Side))
                {
                    copy.children.Add(copyCh);
                }
            }
            return copy;
        }
        public virtual void Insert(IFigureMy par = null)
        {
            IFigureMy test = this;
            if (par == null)
            {
                parent = SEref.Scene;
                SEref.Scene.children.Add(this);
            }
            else parent = par;
            foreach (IFigureMy ch in children)
            {
                ch.Insert(this);
            }
            base_init(true);
            Move();
        }

        public FigureMy(IFigureFactory fFref, ISE ser, IWindowsFactory wf, string Name = "Figure")
        {
            //name = SE.Get_nomber() + "_" + Name;
            
            FFref = fFref;
            SEref = ser;
            canva = SEref.canva;
            WF = wf;
        }
        public virtual void base_init(bool reinitial = false)
        {
            if (parent == null && !(this is Side) && !(this is Scene))
            {
                parent = SEref.Scene;
                SEref.Scene.children.Add(this);
            }
            canva.Children.Add(border);
            canva.Children.Add(CenterPoint);
            SEref.UpdateHierarchy();

        }

        public virtual void Move(double x, double y)
        {
            Point p;
            //if (parent != null) {
            //    p = parent.getGlobal(getLocal(new(x, y)));
            //}
            //else
            p = new Point(x, y);
            glob = p;
            Draw();
            if (RW != null) RW.UpdateData();
        }
        public void Move()
        {
            Move(glob.X, glob.Y);
        }
        public void d_Move(double dx, double dy)
        {
            foreach (FigureMy ch in children)
            {
                if (!(ch is Side)) ch.d_Move(dx, dy);
            }
            Move(glob.X + dx, glob.Y + dy);
        }
        public virtual void d_Move_drag(double dx, double dy)
        {
            //if (parent != null && !(parent is AllFigures))
            //{
            //    parent.d_Move_drag(dx, dy);
            //}
            //else
            //{
            //    Move(glob.X + dx, glob.Y + dy);
            //    foreach (FigureMy ch in children) d_Move(dx, dy);
            //}
            foreach (FigureMy sel in SEref.selected)
            {
                if (sel.parent is Scene) sel.d_Move(dx, dy);
            }
        }
        public virtual void setScale(double new_scale)
        {
            scale = new_scale;
            Draw();
        }

        public virtual void Draw()
        {
            Canvas.SetLeft(CenterPoint, glob.X - CenterPoint.Width / 2);
            Canvas.SetTop(CenterPoint, glob.Y - CenterPoint.Height / 2);

            Update_borders();
            SEref.UpdateHierarchy();
        }
        public virtual void Update_borders()
        {
            double x = Math.Min(b_p1.X, b_p2.X);
            double y = Math.Min(b_p1.Y, b_p2.Y);
            double width = Math.Abs(b_p2.X - b_p1.X);
            double height = Math.Abs(b_p2.Y - b_p1.Y);

            border.Width = width;
            border.Height = height;

            Canvas.SetLeft(border, x);
            Canvas.SetTop(border, y);
            FigureMy test = this;
            if (parent != null) parent.Update_borders();
        }
        public virtual void Edit()
        {
            if (RW != null) return;
            IRedWindow red = WF.new_RW(this);
            RW = red;
            red.Show();
        }
        public virtual void Delete()
        {
            if (parent != null)
            {
                parent.children.Remove(this);
            }
            if (!(this is Scene))
            {
                if (parent != null && parent.children.Count == 0) parent.Delete();
                else if (parent != null && parent is SuperFigure SF)
                {
                    SF.AddFigure(); //здесь это как перерасчёт
                }
                parent = null;
                canva.Children.Remove(border);
                canva.Children.Remove(CenterPoint);
            }

            foreach (FigureMy ch in children.ToList())
            {
                ch.Delete();
            }
            children.Clear();
            SEref.UpdateHierarchy();

        }

        public virtual void Deselect()
        {
            border.Visibility = Visibility.Hidden;
            CenterPoint.Visibility = Visibility.Hidden;
        }
        public virtual void Select()
        {
            border.Visibility = Visibility.Visible;
            CenterPoint.Visibility = Visibility.Visible;
            if (parent != null && !(parent is Scene)) parent.Select();
        }

        public virtual void Rejection()
        {
            if (parent != null)
            {
                dop_angle = 0;
                parent.children.Remove(this);
                if (parent is SuperFigure par) par.AddFigure();
                parent = SEref.Scene;
                SEref.Scene.children.Add(this);
                SEref.UpdateHierarchy();
            }
        }

        public Point getGlobal(Point p)
        {

            // 1. масштаб
            double x = (p.X + center_loc.X) * scale;
            double y = (p.Y + center_loc.Y) * scale;

            // 2. поворот
            double rad = (angle + dop_angle) * Math.PI / 180.0;

            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            double xr = x * cos - y * sin;
            double yr = x * sin + y * cos;

            // 3. перенос
            return new Point(xr + glob.X, yr + glob.Y);
        }
        public Point getLocal(Point p)
        {

            double x = p.X - glob.X;
            double y = p.Y - glob.Y;


            double rad = -(angle + dop_angle) * Math.PI / 180.0;

            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            double xr = x * cos - y * sin;
            double yr = x * sin + y * cos;

            return new Point(xr / scale - center_loc.X, yr / scale - center_loc.Y);
        }

        public virtual void Load(JsonElement el)
        {
            // базовые поля уже заполнены фабрикой
        }
        public virtual void Save(IFigureMy fig, Dictionary<string, object> dict)
        {
            // базовые поля уже заполнены фабрикой
        }


    }


}