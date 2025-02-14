using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using Produktkatalog.Model;


namespace Produktkatalog.ViewModel
{
   public class DetailProductViewModel: ViewModelBase
    {

        private const string JsonFilePath = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        private ObservableCollection<Product> newProductTile;
        public ObservableCollection<Product> NewProductTile
        {
            get { return newProductTile; }
            set
            {
                newProductTile = value;
                OnPropertyChanged(nameof(NewProductTile));
            }
        }

        public ICommand _executeDetailProductCommand { get; set; }
        public ICommand ExecuteDetailProductCommand
        {
            get => _executeDetailProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _executeDetailProductCommand = value; OnPropertyChanged(nameof(ExecuteDetailProductCommand)); }
        }

        private ICommand _changeProductInfoViewCommand { get; set; }
        public ICommand ChangeProductInfoViewCommand
        { 
            get => _changeProductInfoViewCommand ?? new RelayCommand(_ => ProductInfoNavigation());
            set { _changeProductInfoViewCommand = value; OnPropertyChanged(nameof(ChangeProductInfoViewCommand)); }
        }

        public event Action ChangeWindow;

        public event Action ChangeProductInfo;

        public void ProductInfoNavigation()
        {
            ChangeProductInfo?.Invoke();
        }

        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public DetailProductViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            ExecuteDetailProductCommand = new RelayCommand(_ => InvokeChange());
            ChangeProductInfoViewCommand = new RelayCommand(_ => ProductInfoNavigation());
        }
    }
}

