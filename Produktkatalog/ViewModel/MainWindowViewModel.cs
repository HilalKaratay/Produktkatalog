using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produktkatalog.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _logoPath;

    

     public string LogoPath
        {
            get { return _logoPath; } 
            set { _logoPath = value; OnPropertyChanged(nameof(LogoPath));}
        }

        public MainWindowViewModel()
        {
            LogoPath = @"..\Resource\Dial.png";
           
        }
    }
}
