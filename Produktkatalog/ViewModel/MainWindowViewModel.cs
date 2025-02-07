using System.Collections.ObjectModel;
using System.Windows.Input;
using Produktkatalog.Model;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using Produktkatalog.Store;

namespace Produktkatalog.ViewModel {
 class MainWindowViewModel : ViewModelBase
    {

        string saveFile = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        private string _logoPath;
        private ProductTilesViewModel _productTilesViewModel;
        private AddProductViewModel _addProductViewModel;
        private DetailProductViewModel _detailProductViewModel;
        private ViewModelBase _activeViewModel;
        public ObservableCollection<Product> _products; 
        private ICommand _productTilesViewCommand { get; }
        private ICommand _addProductViewCommand { get; }
        private ICommand _detailViewCommand { get; }
       
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
            get => _productTilesViewCommand ?? new RelayCommand(_ => GotToAddProduct());
        }
        public ICommand DetailViewCommand
        {
            get => _detailViewCommand ?? new RelayCommand(_ => GotToProductTiles());
        }

        public MainWindowViewModel()
        {
            LogoPath = @"..\Resources\Dial.png";

            var dataLoader = new JsonDataLoader();
            var products = dataLoader.LoadProducts(saveFile);

            Products = new ObservableCollection<Product>(products);

            ActiveViewModel = ProductTilesView;
           
            ProductTilesView = new ProductTilesViewModel(Products);
            AddProductView = new AddProductViewModel(Products);
            DetailProductView = new DetailProductViewModel(Products);

            ProductTilesView.ChangeWindow += GotToProductDetails;
            AddProductView.ChangeWindow += GotToProductTiles;
            DetailProductView.ChangeWindow += GotToProductTiles;

        }

        public void GotToProductTiles()
        {
            ActiveViewModel = ProductTilesView;
        }
      
        public void GotToProductDetails()
        {
            ActiveViewModel = DetailProductView;
        }
        public void GotToAddProduct()
        {
            ActiveViewModel = AddProductView;
        }
    }
}
