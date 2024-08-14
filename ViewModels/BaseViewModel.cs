using Land_Property_App.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Land_Property_App.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected DatabaseContext _context = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand OpenUrl => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
