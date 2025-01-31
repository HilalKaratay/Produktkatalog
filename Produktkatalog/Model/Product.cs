
namespace Produktkatalog.Model
{
    class Product
    {
        public int ProductId { get; set; } //ProductId für die Liste
        public string ProductName { get; set; } //Produktname
        public string ProductDimension { get; set; } //Produktmaße
        public string ProductFamily { get; set; } //Produktfamilie
        public string ApplicationPlace { get; set; } //Einsatzbereich
        public string Installation { get; set; } //Montageort
        public string MountingType { get; set; } //Montageart
        public string Form { get; set; } //Form
        public string Adjustability { get; set; } //Verstellbarkeit
        public string LumFlux { get; set; } //Lichtstrom
        public string Performance { get; set; } //Leistung
        public string LightYield { get; set; } //Lichtausbeute
        public string ColorRenderingIndex { get; set; } //Farbwiedergabeindex
        public string MoreInformation { get; set; }  //weiter Informationen
        public string BildURL { get; set; }   //Bild Url, um Fotos zu speichern
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
