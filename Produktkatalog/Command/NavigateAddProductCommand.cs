using Produktkatalog.Store;
using Produktkatalog.ViewModel;

namespace Produktkatalog.Command
{
    class NavigateAddProductCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;


        public NavigateAddProductCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            //_navigationStore.CurrentViewModel = new AddProductViewModel(_navigationStore);
        }
    }
}
