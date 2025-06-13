using DesafioTechSub.Models;

namespace DesafioTechSub.IServices
{
    public interface IPaymentMethodService
    {
        Task<PaymentMethod> SavePaymentMethod(PaymentMethod PaymentMethod);
        Task<PaymentMethod?> GetPaymentMethodByIdAsync(Guid id);
        Task<List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<bool> DeletePaymentMethodByIdAsync(Guid id);
    }
}
