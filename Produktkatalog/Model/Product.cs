
using Newtonsoft.Json;

namespace Produktkatalog.Model
{

    //Verweise mit dem Wort JSON werden benötigt, um die Dateien speichern zu können
    [JsonObject(MemberSerialization.OptIn)]
    public class Product
    {

        [JsonProperty]
        public int ProductId { get; set; } //ProductId für die Liste
        [JsonProperty]
        public string ProductName { get; set; } //Produktname
        [JsonProperty]
        public string ProductDimension { get; set; } //Produktmaße
        [JsonProperty]
        public string ProductFamily { get; set; } //Produktfamilie
        [JsonProperty]
        public string ApplicationPlace { get; set; } //Einsatzbereich
        [JsonProperty]
        public string Installation { get; set; } //Montageort
        [JsonProperty]
        public string MountingType { get; set; } //Montageart
        [JsonProperty]
        public string Form { get; set; } //Form
        [JsonProperty]
        public string Adjustability { get; set; } //Verstellbarkeit
        [JsonProperty]
        public string LumFlux { get; set; } //Lichtstrom
        [JsonProperty]
        public string Performance { get; set; } //Leistung
        [JsonProperty]
        public string LightYield { get; set; } //Lichtausbeute
        [JsonProperty]
        public string ColorRenderingIndex { get; set; } //Farbwiedergabeindex
        [JsonProperty]
        public string MoreInformation { get; set; }  //weiter Informationen
        [JsonProperty]
        public string BildURL { get; set; }   //Bild Url, um Fotos zu speichern
        [JsonProperty]
        public string BildURL2 { get; set; }


        /*Konstruktor
        public Product(int productId, string produktname, string produktDimension, string productFamily, string applicationPlace, string installation, 
            string mountingType, string form, string adjustability, string lumFlux, string performance, string lightYield, string colorRenderingIndex, string moreInformation)
            {
                ProductId = productId;
                ProductName = produktname;
                ProductDimension = produktDimension;
                ProductFamily = productFamily;
                ApplicationPlace = applicationPlace;
                Installation = installation;
                MountingType = mountingType;
                Form = form;
                Adjustability = adjustability;
                LumFlux = lumFlux;
                Performance = performance;
                LightYield = lightYield;
                ColorRenderingIndex = colorRenderingIndex;
                MoreInformation = moreInformation;

            }
            */

    }
}
