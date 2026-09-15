using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Category;
using eCommerce.Application.DTOs.Product;

namespace eCommerce.Application.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductByCategory(Guid categoryId);
    }
}
