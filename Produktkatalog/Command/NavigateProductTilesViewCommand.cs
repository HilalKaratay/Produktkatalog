
using Produktkatalog.Store;
using Produktkatalog.ViewModel;

namespace Produktkatalog.Command
{
    class NavigateProductTilesViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        //public AddProductViewModel AddProductViewModel { get; set; }
        
       
        public NavigateProductTilesViewCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
           

        }

        public override void Execute(object parameter)
        {
         //   _navigationStore.CurrentViewModel = new ProductTilesViewModel(_navigationStore);
        }
    }
}
 