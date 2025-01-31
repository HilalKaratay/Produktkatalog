using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Produktkatalog.Command;
using Produktkatalog.Model;
using Produktkatalog.Store;
using Newtonsoft.Json;

namespace Produktkatalog.ViewModel {
 class MainWindowViewModel : ViewModelBase
    {
        private string _logoPath;
        private ProductTilesViewModel _productTilesViewModel;
        private AddProductViewModel _addProductViewModel;
        private DetailProductViewModel _detailProductViewModel;

        private ICommand _productTilesViewCommand { get; }
        private ICommand _addProductViewCommand { get; }
        private ViewModelBase _activeViewModel;

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
            get => _productTilesViewCommand ?? new RelayCommand(_ => InvokeChange());
        }
        public ICommand AddProductViewCommand
        {
            get => _productTilesViewCommand ?? new RelayCommand(_ => InvokeChange());
        }


        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }


        public MainWindowViewModel()
        {  
            LogoPath = @"..\Resources\Dial.png";
            
            
            ProductTilesView = new ProductTilesViewModel();
            AddProductView = new AddProductViewModel();    
            DetailProductView = new DetailProductViewModel();

            ActiveViewModel = AddProductView;

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
