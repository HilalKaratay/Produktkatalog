using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualBasic;
using Produktkatalog.Model;
using Produktkatalog.Store;
using Produktkatalog.View;

namespace Produktkatalog.ViewModel
{
   class DetailProductViewModel: ViewModelBase
    {
        private AddProductViewModel _addProductViewModel;
        public AddProductViewModel AddProductView
        {
            get { return _addProductViewModel; }
            set { _addProductViewModel = value; RaisePropertyChanged(nameof(AddProductView)); }
        }
        public ObservableCollection<Product> newProductTile { get; }

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


        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public DetailProductViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            newProductTile = newProductsAsParameter;
           
        }

            /*
            ProductName.Text = product.ProductName;
            Information.Text = product.MoreInformation;
            Productfamiliy.Text = product.ProductFamily;
            ApplicationPlace.Text = product.ApplicationPlace;
            Installation.Text = product.Installation;
            MountingType.Text = product.MountingType;
            ProductDimension.Text = product.ProductDimension;
            Form.Text = product.Form;
            Adjustability.Text = product.Adjustability;
            ProductLumFlux.Text = product.LumFlux;
            Performance.Text = product.Performance;
            LightYield.Text = product.LightYield;
            ColorRenderingIndex.Text = product.ColorRenderingIndex;*/

   }
}

