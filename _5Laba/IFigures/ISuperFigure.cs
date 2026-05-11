using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba.IFigures
{
    internal interface ISuperFigure
    {
        // Methods
        void base_init(bool reinitial = false);
        void Clone();
        void Insert();
        void Edit();
        void Draw();
        void Update_borders();
        void Delete();
        void Select();
        void Deselect();
        void Load(System.Text.Json.JsonElement el);
        void Save();
        void AddFigure();
        void setScale(double new_scale);
    }
}

