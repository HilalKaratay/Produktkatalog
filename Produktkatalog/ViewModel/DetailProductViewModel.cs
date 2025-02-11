using System.Collections.ObjectModel;
using System.Windows.Input;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
   class DetailProductViewModel: ViewModelBase
    {
        public ObservableCollection<Product> newProductTile { get; }

        private AddProductViewModel _addProductViewModel;
        public AddProductViewModel AddProductView
        {
            get { return _addProductViewModel; }
            set { _addProductViewModel = value; RaisePropertyChanged(nameof(AddProductView)); }
        }
        
        private ProductTilesViewModel _productTilesViewModel;
        public ProductTilesViewModel ProductTilesView
        {
            get { return _productTilesViewModel; }
            set { _productTilesViewModel = value; RaisePropertyChanged(nameof(ProductTilesView)); }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }

        private ICommand _productTilesView;
        public ICommand ProductTilesViewComand
        {
            get => _productTilesView ?? new RelayCommand(_ => InvokeChange());
        }

        private ICommand _changeProductInfoViewCommand;
        public ICommand ChangeProductInfoViewCommand
        { 
            get => _changeProductInfoViewCommand ?? new RelayCommand(_ => InvokeChange());

        }

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public DetailProductViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            newProductTile = newProductsAsParameter;
        }
    }
}

