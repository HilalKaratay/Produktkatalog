using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Produktkatalog.Command;
using Produktkatalog.Model;
using Produktkatalog.Store;
using Newtonsoft.Json;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Produktkatalog.ViewModel
{
    class AddProductViewModel : ViewModelBase
    {
        string saveFile = @"C:\Users\murat\Desktop\Produktkatalog\Produktkatalog\Resources\Product.json";
        public ICommand _addProductCommand { get; set; }
        public ICommand _executeProductCommand { get; set; }
        public ICommand _addPictureOneCommand { get; }
        public ICommand _addPictureTwoCommand { get; }
        public ICommand AddPictureOneCommand { get; }
        public ICommand AddPictureTwoCommand { get; }
        public static ObservableCollection<Product> _products { get; set; }
        private MainWindowViewModel _mainWindowViewModel { get; set; }
        public RelayCommand ProductAddCommand { get;  }
        public string _newProductProductName { get; set; }
        public string _newProductProductfamiliy { get; set; }
        public string _newProductApplicationPlace { get; set; }
        public string _newProductInstallation { get; set; }
        public string _newProductMountingType { get; set; }
        public string _newProductProductDimension { get; set; }
        public string _newProductForm { get; set; }
        public string _newProductAdjustability { get; set; }
        public string _newProductLumFlux { get; set; }
        public string _newProductPerformance { get; set; }
        public string _newProductLightYield { get; set; }
        public string _newProductColorRenderingIndex { get; set; }
        public string _newProductInformation { get; set; }
        public string _newProductBildURL { get; set; }
        public string _newProductBildURL2 { get; set; }

        public MainWindowViewModel MainWindowViewModel
        {
            get { return _mainWindowViewModel; }
            set { _mainWindowViewModel = value; OnPropertyChanged(nameof(MainWindowViewModel)); }
        }
        public string NewProductProductname
        {
            get { return _newProductProductName; }
            set { _newProductProductName = value; OnPropertyChanged(nameof(NewProductProductname)); }
        }
        public string NewProductProductfamiliy
        {
            get { return _newProductProductfamiliy; }
            set { _newProductProductfamiliy = value; OnPropertyChanged(nameof(NewProductProductfamiliy)); }
        }
        public string NewProductApplicationPlace
        {
            get { return _newProductApplicationPlace; }
            set { _newProductApplicationPlace = value; OnPropertyChanged(nameof(NewProductApplicationPlace)); }
        }
        public string NewProductInstallation
        {
            get { return _newProductInstallation; }
            set { _newProductInstallation = value; OnPropertyChanged(nameof(NewProductInstallation)); }
        }
        public string NewProductMountingType
        {
            get { return _newProductMountingType; }
            set { _newProductMountingType = value; OnPropertyChanged(nameof(NewProductMountingType)); }
        }
        public string NewProductProductDimension
        {
            get { return _newProductProductDimension; }
            set { _newProductProductDimension = value; OnPropertyChanged(nameof(NewProductProductDimension)); }
        }
        public string NewProductForm
        {
            get { return _newProductForm; }
            set { _newProductForm = value; OnPropertyChanged(nameof(NewProductForm)); }
        }
        public string NewProductAdjustability
        {
            get { return _newProductAdjustability; }
            set { _newProductAdjustability = value; OnPropertyChanged(nameof(NewProductAdjustability)); }
        }
        public string NewProductLumFlux
        {
            get { return _newProductLumFlux; }
            set { _newProductLumFlux = value; OnPropertyChanged(nameof(NewProductLumFlux)); }
        }
        public string NewProductPerformance
        {
            get { return _newProductPerformance; }
            set { _newProductPerformance = value; OnPropertyChanged(nameof(NewProductPerformance)); }
        }
        public string NewProductLightYield
        {
            get { return _newProductLightYield; }
            set { _newProductLightYield = value; OnPropertyChanged(nameof(NewProductLightYield)); }
        }
        public string NewProductColorRenderingIndex
        {
            get { return _newProductColorRenderingIndex; }
            set { _newProductColorRenderingIndex = value; OnPropertyChanged(nameof(NewProductColorRenderingIndex)); }
        }
        public string NewProductInformation
        {
            get { return _newProductInformation; }
            set { _newProductInformation = value; OnPropertyChanged(nameof(NewProductInformation)); }
        }
        public string NewProductBildURL
        {
            get { return _newProductBildURL; }
            set { _newProductBildURL = value; OnPropertyChanged(nameof(NewProductBildURL)); }
        }
        public string NewProductBildURL2
        {
            get { return _newProductBildURL2; }
            set { _newProductBildURL2 = value; OnPropertyChanged(nameof(NewProductBildURL2)); }
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(nameof(Products)); }
        }
        public ICommand AddProductCommand
        {
            get => _addProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _addProductCommand = value; OnPropertyChanged(nameof(AddProductCommand)); }
        }
        public ICommand ExecuteProductCommand
        {
            get => _executeProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _executeProductCommand = value; OnPropertyChanged(nameof(ExecuteProductCommand)); }
        }
        public event Action ChangeWindow;

        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        //Funktionen für das hinzufügen eines neuen Produkts
        public void AddProduct()
        {
            int productId = 1;
            if (Products.Any())
            {
                productId = Products.OrderByDescending(x => x.ProductId).First().ProductId + 1;
            }

            var product = new Product
            {
                ProductId = productId,
                ProductName = _newProductProductName,
                ProductFamily = _newProductProductfamiliy,
                ApplicationPlace = _newProductApplicationPlace,
                Installation = _newProductInstallation,
                MountingType = _newProductMountingType,
                ProductDimension = _newProductProductDimension,
                Form = _newProductForm,
                Adjustability = _newProductAdjustability,
                LumFlux = _newProductLumFlux,
                Performance = _newProductPerformance,
                ColorRenderingIndex = _newProductColorRenderingIndex,
                MoreInformation = _newProductInformation,
                BildURL = _newProductBildURL,
                BildURL2 = _newProductBildURL2
            };
            //If-Anweisung um festzusetzen, dass der Nutzer alle Textfelder ausgefüllt hat!
            if (string.IsNullOrWhiteSpace(_newProductProductName) || string.IsNullOrWhiteSpace(_newProductProductfamiliy) || string.IsNullOrWhiteSpace(_newProductApplicationPlace) || string.IsNullOrWhiteSpace(_newProductInstallation) ||
                string.IsNullOrWhiteSpace(_newProductMountingType) || string.IsNullOrWhiteSpace(_newProductMountingType) || string.IsNullOrWhiteSpace(_newProductProductDimension) || string.IsNullOrWhiteSpace(_newProductForm) ||
                string.IsNullOrWhiteSpace(_newProductAdjustability) || string.IsNullOrWhiteSpace(_newProductLumFlux) || string.IsNullOrWhiteSpace(_newProductPerformance) || string.IsNullOrWhiteSpace(_newProductColorRenderingIndex) ||
                string.IsNullOrWhiteSpace(_newProductInformation))
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus, um das Produkt zu speichern.");
                return;
            }

            Products.Add(product);

            JsonSerializer jsonSerializer = new JsonSerializer();

            // Stream zum speichern in eine Datei
            using (StreamWriter sw = File.CreateText(saveFile)) 
            {
                jsonSerializer.Serialize(sw, _products);
            }
        }

        private void AddingPictureOne()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Bilder (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                NewProductBildURL = openFileDialog.FileName;
            }
        }

        private void AddingPictureTwo()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Bilder (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                NewProductBildURL2 = openFileDialog.FileName;
            }
        }

        public AddProductViewModel(ObservableCollection<Product> productsAsParameter)
        {
            AddPictureOneCommand = new RelayCommand(param=> { AddingPictureOne(); });
            AddPictureTwoCommand = new RelayCommand(param => { AddingPictureTwo(); });

            ProductAddCommand = new RelayCommand(param => { AddProduct();});
            AddProductCommand = new RelayCommand(_ => InvokeChange());
            ExecuteProductCommand = new RelayCommand(_ => InvokeChange()); 
            _products = productsAsParameter;
            ProductTilesViewModel newProduct = new ProductTilesViewModel(Products);
          
        }
    }
}

