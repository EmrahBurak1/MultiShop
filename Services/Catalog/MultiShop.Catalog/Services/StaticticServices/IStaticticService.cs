namespace MultiShop.Catalog.Services.StaticticServices
{
    public interface IStaticticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
    }
}
