using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba_InterfacesLibrary
{
    public interface ISuperFigure : IFigureMy
    {
        // Methods
        void base_init(bool reinitial = false);
        IFigureMy Clone(IFigureMy part = null, IFigureMy parentCop = null);
        void Update_borders();
        void AddFigure(IFigureMy figure = null);
        void setScale(double new_scale);

        void Rotate(double newAngle, double delta_dop_angle = 0);
    }
}

