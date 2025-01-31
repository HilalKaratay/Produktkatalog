using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Produktkatalog.Store;
using Produktkatalog.View;

namespace Produktkatalog.ViewModel
{
  public  class DetailProductViewModel: ViewModelBase
    {
        private ICommand _productTilesView;

        public ICommand ProductTilesView
        {
            get => _productTilesView ?? new RelayCommand(_ => InvokeChange());
        }

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }

        public DetailProductViewModel()
        { 

        }

    }
}
