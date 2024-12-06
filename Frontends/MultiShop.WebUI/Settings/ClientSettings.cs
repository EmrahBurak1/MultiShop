namespace MultiShop.WebUI.Settings
{
    public class ClientSettings //Appsettings içinde tanımlanan client bilgilerini almak için kullanılır.
    {
        public Client MultiShopVisitorClient { get; set; }
        public Client MultiShopManagerClient { get; set; }
        public Client MultiShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
