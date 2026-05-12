using _5Laba_InterfacesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba_library
{
    //Класс сцены
    public class Scene : SuperFigure, IScene
    {
        public Scene(IFigureFactory fFref, ISE ser, IWindowsFactory wf) : base(fFref, ser, wf)
        {
            name = "Сцена";
            type = "scene";
        }

        public override void Insert(IFigureMy par = null)
        {
            foreach (FigureMy ch in children)
            {
                ch.Insert(this);
            }
            base_init(true);
        }

        public override void Select()
        {

        }
        public override void Deselect()
        {

        }
    }
}
