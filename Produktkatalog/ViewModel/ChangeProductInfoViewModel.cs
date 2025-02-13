using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
    public class ChangeProductInfoViewModel : ViewModelBase
    {
        public ICommand _backToDetailProductCommand { get; set; }
        public ICommand BackToDetailProductCommand
        {
            get => _backToDetailProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _backToDetailProductCommand = value; OnPropertyChanged(nameof(BackToDetailProductCommand)); }
        }

        public ICommand _updateProductCommand { get; set; }
        public ICommand UpdateProductCommand
        {
            get => _updateProductCommand ?? new RelayCommand(_ => InvokeChange());
            set { _updateProductCommand = value; OnPropertyChanged(nameof(UpdateProductCommand)); }
        }

        public event Action UpdateProductInfo;

        public void InvokeUpdateChange()
        {
            UpdateProductInfo?.Invoke();
        }

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public ChangeProductInfoViewModel(ObservableCollection<Product> newProductsAsParameter)
        {
            UpdateProductCommand = new RelayCommand(_ => InvokeUpdateChange());
            BackToDetailProductCommand = new RelayCommand(_ => InvokeChange());
        }

}
}
