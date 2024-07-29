namespace MultiShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings //Appsettingste bulunan Collectionların tanımlandığı yer. Örneğin appsettingsteki connection stringi kullanmak yerine bu sınıftan nesne türetiliyor. Gerekli eşleştirmeler appsetting içinde yapılıyor.
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImagesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
