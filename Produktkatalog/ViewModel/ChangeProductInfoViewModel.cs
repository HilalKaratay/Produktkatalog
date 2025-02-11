using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produktkatalog.Model;

namespace Produktkatalog.ViewModel
{
    class ChangeProductInfoViewModel : ViewModelBase
    {

        public event Action ChangeWindow;
        public void InvokeChange()
        {
            ChangeWindow?.Invoke();
        }


        public ChangeProductInfoViewModel(ObservableCollection<Product> newProductsAsParameter)
        {


      

    }

}
}
