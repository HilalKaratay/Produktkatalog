using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using Produktkatalog.Model;
using Produktkatalog.Store;

namespace Produktkatalog.ViewModel {
public class MainWindowViewModel : ViewModelBase
    {
        string saveFile = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        private string _logoPath;
        private ProductTilesViewModel _productTilesViewModel { get; set; }
        private AddProductViewModel _addProductViewModel;
        private DetailProductViewModel _detailProductViewModel;
        private ViewModelBase _activeViewModel;
        private ChangeProductInfoViewModel _changeProductInfoViewModel;

        public ObservableCollection<Product> _products; 
        private ICommand _productTilesViewCommand { get; }
        private ICommand _addProductViewCommand { get; }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                
            }
        }


        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(nameof(Products)); }
        }
        public ProductTilesViewModel ProductTilesView
        {
            get { return _productTilesViewModel; }
            set{ _productTilesViewModel = value; RaisePropertyChanged(nameof(ProductTilesView)); }
        }
        public DetailProductViewModel DetailProductView
        {
            get { return _detailProductViewModel; }
            set { _detailProductViewModel = value; RaisePropertyChanged(nameof(DetailProductView)); }
        }
        public AddProductViewModel AddProductView
        {
            get { return _addProductViewModel; }
            set { _addProductViewModel = value; RaisePropertyChanged(nameof(AddProductView)); }
        }
        public ChangeProductInfoViewModel ChangeProductInfoView
        {
                get { return _changeProductInfoViewModel; }
                set { _changeProductInfoViewModel = value; RaisePropertyChanged(nameof(ChangeProductInfoView)); }
        }
        public ViewModelBase ActiveViewModel
        {
            get { return _activeViewModel; }
            set { _activeViewModel = value; RaisePropertyChanged(nameof(ActiveViewModel)); }
        }
        public string LogoPath
        {
            get { return _logoPath; } 
            set { _logoPath = value; OnPropertyChanged(nameof(LogoPath));}
        }
        public ICommand ProductTilesViewCommand
        {
            get => _productTilesViewCommand ?? new RelayCommand(_ => GotToProductTiles());
        }
        public ICommand AddProductViewCommand
        {
            get => _addProductViewCommand ?? new RelayCommand(_ => GotToAddProduct());
        }
        public MainWindowViewModel()
        {
            LogoPath = @"..\Resources\Dial.png";
            var dataLoader = new JsonDataLoader();
            var products = dataLoader.LoadProducts(saveFile);

            Products = new ObservableCollection<Product>(products);
            
            ChangeProductInfoView = new ChangeProductInfoViewModel(Products);
            ProductTilesView = new ProductTilesViewModel(Products);
            AddProductView = new AddProductViewModel(Products);
            DetailProductView = new DetailProductViewModel(Products);

            ProductTilesView.ChangeWindow += GoToProductDetails;
            AddProductView.ChangeWindow += GotToProductTiles;
            DetailProductView.ChangeWindow += GotToProductTiles;
            DetailProductView.ChangeProductInfo += GoToChangeProduktInfo;
            ChangeProductInfoView.UpdateProductInfo += GoToProductDetails;
            ChangeProductInfoView.ChangeWindow += GoToProductDetails;

            ActiveViewModel = ProductTilesView;
        }

        public void GoToChangeProduktInfo()
        {
            ActiveViewModel = ChangeProductInfoView;
        }

        public void GotToProductTiles()
        {
            ActiveViewModel = ProductTilesView;
        }
      
        public void GoToProductDetails()
        {
            ActiveViewModel = DetailProductView;
        }
        public void GotToAddProduct()
        {
            ActiveViewModel = AddProductView;
        }
    }
}
