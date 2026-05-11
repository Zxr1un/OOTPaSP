using _5Laba_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Laba.IFigures
{
    internal interface IFactory
    {
        // Methods
        FigureMy FromJson(string json);
        FigureMy CreateByType(string type);
        string GetString(System.Text.Json.JsonElement el, string name);
        double GetDouble(System.Text.Json.JsonElement el, string name, double def = 0);
        System.Windows.Point GetPoint(System.Text.Json.JsonElement el, string name);
        bool TryGetString(System.Text.Json.JsonElement el, string name, out string value);
    }
}

