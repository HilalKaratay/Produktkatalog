using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Produktkatalog.Command;
using Produktkatalog.Model;
using Produktkatalog.Store;
using Newtonsoft.Json;

namespace Produktkatalog.ViewModel
{
    class AddProductViewModel: ViewModelBase
    {
        private ICommand _addProductCommand { get; set; }
        public RelayCommand ProductAddCommand {  get; }
        private ICommand _deleteProductCommand { get; }
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

        public ObservableCollection<Product> _products { get; set; }

        public Product _selectedProduct;

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

         public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct));}
        }

      /*
        public RelayCommand ProductAddCommand
        {
            get { return _productaddCommand; }
            set { _productaddCommand = value; OnPropertyChanged(nameof(ProductAddCommand)); }
        } */
        
        public ICommand AddProductCommand
        {
            get => _addProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _addProductCommand = value; OnPropertyChanged(nameof(AddProductCommand)); }
        }

        public ICommand DeleteProductCommand
        {
            get => _deleteProductCommand ?? new RelayCommand(_ => InvokeChange());
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
               // ProductId = productId,
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
               /* BildURL = _newProductBildURL,
                BildURL2 = _newProductBildURL2,*/
            };
            //If-Anweisung um festzusetzen, dass der Nutzer alle Textfelder ausgefüllt hat!
            if (string.IsNullOrWhiteSpace(_newProductProductName) || string.IsNullOrWhiteSpace(_newProductProductfamiliy) || string.IsNullOrWhiteSpace(_newProductApplicationPlace) || string.IsNullOrWhiteSpace(_newProductInstallation) ||
                string.IsNullOrWhiteSpace(_newProductMountingType) || string.IsNullOrWhiteSpace(_newProductMountingType) || string.IsNullOrWhiteSpace(_newProductProductDimension) || string.IsNullOrWhiteSpace(_newProductForm) ||
                string.IsNullOrWhiteSpace(_newProductAdjustability) || string.IsNullOrWhiteSpace(_newProductLumFlux) || string.IsNullOrWhiteSpace(_newProductPerformance) || string.IsNullOrWhiteSpace(_newProductColorRenderingIndex) ||
                string.IsNullOrWhiteSpace(_newProductInformation)){

                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
                return;
            }

            Products.Add(product);
           // string jsonString = JsonConvert.SerializeObject(product);
        }



        //Bearbeiten eines Produktes
        public void ChangeProductInformations()
        {
        }

        public AddProductViewModel()
        {
            /*Products = new ObservableCollection<Product>
             {
                 new Product { ProductName="Test 1", ProductFamily="Test 1", ApplicationPlace="Test 1", Installation="Test 1", MountingType="Test 1", ProductDimension="Test 1", Form="Test 1", Adjustability="Test 1",
                 LumFlux="Test 1", Performance="Test 1", ColorRenderingIndex="Test 1", MoreInformation="Test 1", BildURL="Test 1", BildURL2="Test 1"}
             };*/
            
            Products = new ObservableCollection<Product>();
            ProductAddCommand = new RelayCommand(param => { AddProduct();});
            AddProductCommand = new RelayCommand(_ => InvokeChange());

        }
    }
}

