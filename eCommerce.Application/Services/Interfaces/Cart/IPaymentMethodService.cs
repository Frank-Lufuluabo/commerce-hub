using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services.Interfaces.Cart
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods();
    }
}
