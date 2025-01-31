
using System.Windows.Input;

namespace Produktkatalog.ViewModel
{
    class ProductTilesViewModel : ViewModelBase
    {
        private AddProductViewModel _addProductViewModel;

        public AddProductViewModel AddProductViewModel
        {
            get { return _addProductViewModel; }
            set
            {
                _addProductViewModel = value; OnPropertyChanged(nameof(AddProductViewModel));
            }
        }

        public ICommand _productDetailsCommand { get;  }
        public ICommand ProductDetailsCommand
        {
            get => _productDetailsCommand ?? new RelayCommand(_ => InvokeChange());
        }

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public ProductTilesViewModel()
        {
            AddProductViewModel =new AddProductViewModel();
           
             
        }
    }
}
    
