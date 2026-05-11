using System.Windows.Controls;

namespace _5Laba.AWindows
{
    public interface IMainWindow
    {
        void SetUniteEnabled();
        void SetUniteDisabled();
        MenuItem GetSavedMenu();
        void Close();
        void Show();
        void Hide();
    }
}
