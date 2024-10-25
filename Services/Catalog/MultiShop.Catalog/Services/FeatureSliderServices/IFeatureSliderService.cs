using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync(); //List olarak ResultCategoryDto'yu döndürecek.
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);

        Task FeatureSliderChangeStatusToTrue(string id); //Bizim featureslider'ımızın statu değerini true'ya çevirecek.
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
