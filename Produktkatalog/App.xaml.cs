﻿using System.Configuration;
using System.Data;
using System.Windows;
using Produktkatalog.Store;
using Produktkatalog.ViewModel;

namespace Produktkatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
          
       // NavigationStore navigationStore = new NavigationStore();

           //navigationStore.CurrentViewModel = new AddProductViewModel();
         
            base.OnStartup(e);
        }
    }
}
