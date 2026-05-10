using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _5Laba_library
{
    public interface IMainWindow
    {
        public void SetUniteEnabled()
        {
            //Unite.IsEnabled = SE.selected.Count > 1;
        }
        public void SetUniteDisabled()
        {
            //Unite.IsEnabled = false;
        }
        public MenuItem GetSavedMenu()
        {
            return null;
        }
        public void Close()
        {

        }
        public void Show()
        {

        }
        public void Hide()
        {

        }
    }
}
