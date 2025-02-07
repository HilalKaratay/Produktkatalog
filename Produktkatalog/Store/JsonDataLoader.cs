using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Produktkatalog.Model;

namespace Produktkatalog.Store
{
    public class JsonDataLoader
    {
        public ObservableCollection<Product> LoadProducts(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
        }
    }



}
