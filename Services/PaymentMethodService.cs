using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechSub.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly Context _context;
        public PaymentMethodService(Context context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> SavePaymentMethod(PaymentMethod paymentMethod)
        {
            if (!paymentMethod.Id.HasValue)
                _context.Add(paymentMethod);
            else
                _context.Update(paymentMethod);

            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<bool> DeletePaymentMethodByIdAsync(Guid id)
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            if (!(paymentMethod is object))
                return false;

            _context.PaymentMethods.Remove(paymentMethod);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(Guid id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
