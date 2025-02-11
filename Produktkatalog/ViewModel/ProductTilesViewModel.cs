
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
    class ProductTilesViewModel : ViewModelBase
    {
        public ObservableCollection<Product> newProductTile { get; set; } = new();
        
        private const string JsonFilePath = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct; 
            set
            {       _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                //MainWindowViewModel.Instance.ActiveViewModel = "DetailProductViewModel";
            }
        }
        public void SelectProduct(object parameter)
        {
            if(parameter is Product product)
            {
                SelectedProduct = product;
                GoToDetailView();
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
        public void GoToDetailView()
        {
            ChangeWindow?.Invoke();
        }
        public void DoubleClickMethod()
        {
            GoToDetailView();
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

        public void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                newProductTile.Remove(SelectedProduct);
                SaveJsonProducts();
            }
            //var product = newProductTile.Remove(newProductTile.FirstOrDefault(p => p.ProductId == id));
            MessageBox.Show("Produkt wurde von der Liste entfernt!");

            LoadProducts(); 
        }
        private void SaveJsonProducts()
        {
            string newJsonDoc = JsonConvert.SerializeObject(newProductTile);
            File.WriteAllText(JsonFilePath, newJsonDoc);
        }
     
        public ProductTilesViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            LoadProducts();
            newProductTile = newProductsAsParameter;
            OnDeleteProductCommand = new RelayCommand(param => { DeleteProduct(); });
        }
    }
}
    
