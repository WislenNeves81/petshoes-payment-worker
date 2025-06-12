namespace PetShoes.Payment.Worker.Core.Services.Interface
{
    public interface IPayPurchaseOrder
    {
        Task<bool> PayPurchaseOrderWithCreditCardAsync(string paymentType);
    }
}
