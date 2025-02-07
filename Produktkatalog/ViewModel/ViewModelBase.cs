
using System.ComponentModel;

namespace Produktkatalog.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged //Das ist das Interface,welches die Eingaben der Benutzer erkennt.
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}