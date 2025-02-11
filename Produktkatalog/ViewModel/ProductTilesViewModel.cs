
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
        
        public DetailProductViewModel _detailpProductViewModel;
        private Product _selectedProduct;

        private const string JsonFilePath = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        public ObservableCollection<Product> newProductTile { get; set; }


        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }


        }
        public DetailProductViewModel DetailProductViewModel
        {
            get { return _detailpProductViewModel; }
            set{_detailpProductViewModel = value; OnPropertyChanged(nameof(DetailProductViewModel));}
        }

        public ICommand _detailViewCommand { get; set; }
        public ICommand DetailViewCommand
        {
            get => _detailViewCommand ?? new RelayCommand(_ => InvokeChange());
            set { _detailViewCommand = value; OnPropertyChanged(nameof(DetailViewCommand)); }
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
            MessageBox.Show("Produkt wurde von der Liste entfernt!");

            SaveJsonProducts();
            LoadProducts(); 
        }

        private void SaveJsonProducts()
        {
            string newJsonDoc = JsonConvert.SerializeObject(newProductTile);
            File.WriteAllText(JsonFilePath, newJsonDoc);
        }

        public void DoubleClickMethod()
        {
            GoToDetailView();
        }


        public ProductTilesViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            LoadProducts();
            DetailViewCommand = new RelayCommand(_ => GoToDetailView());
            newProductTile = newProductsAsParameter;
            OnDeleteProductCommand = new RelayCommand(param => { DeleteProduct((int)param); });
        }
    }
}
    
