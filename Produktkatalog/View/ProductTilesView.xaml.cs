
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Produktkatalog.Model;
using Produktkatalog.ViewModel;

namespace Produktkatalog.View
{
    public partial class ProductTilesView : UserControl
    {
        public ProductTilesView()
        {
            InitializeComponent();
            ProductTileListView.ItemsSource = AddProductViewModel._products;
        }

       
    }
}
