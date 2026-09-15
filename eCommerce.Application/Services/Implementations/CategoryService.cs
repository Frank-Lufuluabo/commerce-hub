using AutoMapper;
using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Category;
using eCommerce.Application.DTOs.Product;
using eCommerce.Application.Service.Interface;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Interfaces.CategorySpecifics;


namespace eCommerce.Application.Service.Implementation
{
    public class CategoryService(IGeneric<Category> categoryInterface, IMapper mapper, ICategory categorySpecifics) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await categoryInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category added!") :
                new ServiceResponse(false, "Category failed to be added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await categoryInterface.DeleteAsync(id);

            return result > 0 ? new ServiceResponse(true, "Category deleted!") :
                new ServiceResponse(false, "Category failed or to be delete.");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var rawData = await categoryInterface.GetAllAsync();
            if (!rawData.Any()) return [];

            return mapper.Map<IEnumerable<GetCategory>>(rawData);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var rawData = await categoryInterface.GetByIdAsync(id);
            if (rawData == null) return new GetCategory();

            return mapper.Map<GetCategory>(rawData);
        }

        public async Task<IEnumerable<GetProduct>> GetProductByCategory(Guid categoryId)
        {
            var products = await categorySpecifics.GetProductsByCategory(categoryId);
            if (!products.Any())
                return [];

            return mapper.Map<IEnumerable<GetProduct>>(products);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await categoryInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category updated!!") :
                new ServiceResponse(false, "Category failed to be updated!");
        }
    }
}
