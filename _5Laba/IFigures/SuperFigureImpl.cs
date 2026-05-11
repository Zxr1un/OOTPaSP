using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _5Laba.IFigures
{
    /// <summary>
    /// Реализация интерфейса ISuperFigure на основе класса SuperFigure из библиотеки
    /// </summary>
    internal class SuperFigureImpl : ISuperFigure
    {
        private SuperFigure _superFigure;

        public SuperFigureImpl() : this(new SuperFigure()) { }

        public SuperFigureImpl(SuperFigure superFigure)
        {
            _superFigure = superFigure ?? throw new ArgumentNullException(nameof(superFigure));
        }

        public void base_init(bool reinitial = false) => _superFigure.base_init(reinitial);

        public void Clone() => _superFigure.Clone();

        public void Insert() => _superFigure.Insert();

        public void Edit() => _superFigure.Edit();

        public void Draw() => _superFigure.Draw();

        public void Update_borders() => _superFigure.Update_borders();

        public void Delete() => _superFigure.Delete();

        public void Select() => _superFigure.Select();

        public void Deselect() => _superFigure.Deselect();

        public void Load(JsonElement el) => _superFigure.Load(el);

        public void Save() => _superFigure.Save(_superFigure, new Dictionary<string, object>());

        public void AddFigure() => _superFigure.AddFigure();

        public void setScale(double new_scale) => _superFigure.setScale(new_scale);
    }
}
