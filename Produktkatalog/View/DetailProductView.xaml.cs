
using System.Windows.Controls;
using Produktkatalog.Model;
using Produktkatalog.ViewModel;

namespace Produktkatalog.View
{
    /// <summary>
    /// Interaktionslogik für DetailProductView.xaml
    /// </summary>
    public partial class DetailProductView : UserControl
    {
       
        // NavigationStore navigationStore = new NavigationStore();
        public  DetailProductView()
        { 
            InitializeComponent();
            this.DataContext = AddProductViewModel._products;
           
        }
    }
}

