using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace _5Laba.IFigures
{
    /// <summary>
    /// Реализация интерфейса IFactory на основе класса FigureFactory из библиотеки
    /// </summary>
    internal class FactoryImpl : IFactory
    {
        public FigureMy FromJson(string json) => FigureFactory.FromJson(json);

        public FigureMy CreateByType(string type)
        {
            return type switch
            {
                "circle" => new Circle(),
                "polygon" => new PolygonMy(),
                "superfigure" => new SuperFigure(),
                "side" => new Side(null, new(0, 0), new(0, 0)),
                "scene" => new AllFigures(),
                _ => new FigureMy()
            };
        }

        public string GetString(JsonElement el, string name) => FigureFactory.GetString(el, name);

        public double GetDouble(JsonElement el, string name, double def = 0) => FigureFactory.GetDouble(el, name, def);

        public Point GetPoint(JsonElement el, string name) => FigureFactory.GetPoint(el, name);

        public bool TryGetString(JsonElement el, string name, out string value)
        {
            var str = GetString(el, name);
            value = str;
            return !string.IsNullOrEmpty(str);
        }
    }
}
