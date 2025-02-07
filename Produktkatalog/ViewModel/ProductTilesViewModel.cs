
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
    class ProductTilesViewModel : ViewModelBase
    {
        public AddProductViewModel _addProductViewModel;
        public DetailProductViewModel _detailpProductViewModel;
        private Product _selectedProduct;
        public ObservableCollection<Product> newProductTile { get; }
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }

        public AddProductViewModel AddProductViewModel
        {
            get { return _addProductViewModel; }
            set {_addProductViewModel = value; OnPropertyChanged(nameof(AddProductViewModel));}
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
            get { return _onDeleteProductCommand;  }
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
        public void GoBackAndSave()
        {
            ChangeWindow?.Invoke();
        }
        public void DeleteProduct(int id)
        {
            newProductTile.Remove(newProductTile.First(p=> p.ProductId == id));
            MessageBox.Show("Produkt wurde von der Liste entfernt!");
        }

        public ProductTilesViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            DetailViewCommand = new RelayCommand(_ => InvokeChange());
            newProductTile = newProductsAsParameter;
            //Funktion zum löschen aus der ListView funkt aber nicht :)
            OnDeleteProductCommand = new RelayCommand(param => { DeleteProduct((int)param); });
        }
  

    }
}
    
