using System.Windows;
using Produktkatalog.Store;
using Produktkatalog.View;
using Produktkatalog.ViewModel;

namespace Produktkatalog
{
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
         
        }

    }
}