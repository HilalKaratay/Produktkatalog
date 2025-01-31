using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Produktkatalog
{
    public class ProductValidation: ValidationRule
    {        
        public string _newProductProductname { get; }
        public string _newProductProductfamiliy { get;}
        public string _newProductApplicationPlace { get; }
        public string _newProductInstallation { get;}
        public string _newProductMountingType { get; }
        public string _newProductProductDimension { get; }
        public string _newProductForm { get; }
        public string _newProductAdjustability { get; }
        public string _newProductLumFlux { get; }
        public string _newProductPerformance { get;}
        public string _newProductLightYield { get;  }
        public string _newProductColorRenderingIndex { get; }
        public string _newProductInformation { get;  }
        public string _newProductBildURL { get; }
        public string _newProductBildURL2 { get; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var _newProductProductname = value as string;
            var _newProductProductfamiliy = value as string;
            var _newProductApplicationPlace = value as string;
            var _newProductInstallation = value as string;
            var _newProductMountingType = value as string;
            var _newProductProductDimension = value as string;
            var _newProductForm = value as string;
            var _newProductAdjustability = value as string;
            var _newProductLumFlux = value as string;
            var _newProductPerformance = value as string;
            var _newProductLightYield = value as string; 
            var _newProductColorRenderingIndex = value as string;
            var _newProductInformation = value as string;


            //Hier muss die Definition rein, dass Feld eine Eingabe benötigt
            try
            { 

            }

            catch(Exception e)
            {
                return new ValidationResult(false, "Some informtions are left. Every field has to be filled with an Information!" + e.Message);
            }
            return new ValidationResult(true, null);
        }
    }
}
