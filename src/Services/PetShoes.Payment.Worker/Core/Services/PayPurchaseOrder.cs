using System;
using PetShoes.Payment.Worker.Core.Services.Interface;

namespace PetShoes.Payment.Worker.Core.Services
{
    public class PayPurchaseOrder : IPayPurchaseOrder
    {
        public async Task<bool> PayPurchaseOrderWithCreditCardAsync(string paymentType)
        {
            var result = false;
            if (paymentType == "CreditCard")
            {
                await Task.Delay(500);
                Random random = new Random();
                result = random.Next(0, 2) == 1;
            }

            return result;
            //ENVIAR A RESPOSTA PARA O ADAPTER DE ORDER
        }
    }
}
