using eCommerce.Domain.Entities;
namespace eCommerce.Domain.Interfaces.CategorySpecifics
{
    public interface ICategory
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
