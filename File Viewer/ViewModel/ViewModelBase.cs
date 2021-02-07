using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileViewer.UI.ViewModel
{
    /// <summary>
    /// Klass som underlättar för uppdateringar av visuella ändringar.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}