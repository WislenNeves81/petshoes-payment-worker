using PetShoes.Payment.Worker.Core.Services.Interface;

namespace PetShoes.Payment.Worker.Core.Services
{
    public class PayPurchaseOrder : IPayPurchaseOrder
    {
        public async Task<bool> PayPurchaseOrderWithCreditCardAsync()
        {
            await Task.Delay(500); 
            Random random = new Random();
            return random.Next(0, 2) == 1; 
        }
    }
}
