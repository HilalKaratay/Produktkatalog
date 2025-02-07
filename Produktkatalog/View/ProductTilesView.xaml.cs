
using System.Windows;
using System.Windows.Controls;
using Produktkatalog.Model;
using Produktkatalog.ViewModel;

namespace Produktkatalog.View
{
    public partial class ProductTilesView : UserControl
    {
        //NavigationStore navigationStore = new NavigationStore();
        public ProductTilesView()
        {
            InitializeComponent();
            this.DataContext = AddProductViewModel._products;
            ProductTileListView.ItemsSource = AddProductViewModel._products;
        }
    }
}
