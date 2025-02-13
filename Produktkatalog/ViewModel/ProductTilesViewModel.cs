
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
    public class ProductTilesViewModel : ViewModelBase
    {
        public ObservableCollection<Product> newProductTile { get; set; }
        private const string JsonFilePath = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        public ObservableCollection<Product> NewProductTile
        {
            get { return newProductTile; }
            set
            {
                newProductTile = value;
                OnPropertyChanged(nameof(NewProductTile));
            }
        }

        public ICommand DetailViewCommand { get; set; }

        /*  public ICommand DetailViewCommand
          {
              get => _detailViewCommand ?? new RelayCommand(_ => InvokeChange());
              set
              {
                  _detailViewCommand = value; OnPropertyChanged(nameof(DetailViewCommand));
              }
          }*/

        private void OpenDetailView(Product produkt)
        {
            if (produkt != null)
            {
                InvokeChange();
                
            }
        }


        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                new RelayCommand(_ => InvokeChange());
                SetProperty(ref _selectedProduct, value);
              
            }
        }

        public ICommand _onDeleteProductCommand { get; set; }
        public ICommand OnDeleteProductCommand
        {
            get { return _onDeleteProductCommand; }
            set { _onDeleteProductCommand = value; OnPropertyChanged(nameof(OnDeleteProductCommand)); }
        }

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }
       
        public void LoadProducts()
        {
            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                var products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
                newProductTile = products ?? new ObservableCollection<Product>();
            }
            else
            {
                newProductTile = new ObservableCollection<Product>();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = newProductTile.Remove(newProductTile.FirstOrDefault(p => p.ProductId == id));
            
            SaveJsonProducts();
            MessageBox.Show("Produkt wurde aus der Liste entfernt!");
        }
        private void SaveJsonProducts()
        {
            string newJsonDoc = JsonConvert.SerializeObject(newProductTile);
            File.WriteAllText(JsonFilePath, newJsonDoc);
        }

        public ProductTilesViewModel(ObservableCollection<Product> newProductsAsParameter)
        {           
            newProductTile = newProductsAsParameter;
            OnDeleteProductCommand = new RelayCommand(param => { DeleteProduct((int)param); });
            //DetailViewCommand = new RelayCommand(param => {InvokeChange();});
            LoadProducts();
            //DetailViewCommand = new RelayCommand(_ => InvokeChange());
            DetailViewCommand = new RelayCommandTwo<Product>(OpenDetailView);

        }
    }
}
    
