using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Produktkatalog.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged //Das ist das Interface,welches die Eingaben der Benutzer erkennt.
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void AtPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage,
           T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            AtPropertyChanged(new PropertyChangedEventArgs(propertyName));

            return true;
        }

    }
}