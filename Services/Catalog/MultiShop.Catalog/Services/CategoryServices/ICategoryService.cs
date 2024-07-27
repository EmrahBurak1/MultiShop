using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService //Categori için CRUD işlemleri yapmada kullanılacak.
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); //List olarak ResultCategoryDto'yu döndürecek.
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
