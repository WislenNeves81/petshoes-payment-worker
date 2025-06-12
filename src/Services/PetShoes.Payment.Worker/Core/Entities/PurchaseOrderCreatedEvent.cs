namespace PetShoes.Payment.Worker.Core.Entities
{
    public class PurchaseOrderCreatedEvent
    {
        public PurchaseOrderCreatedEvent(string paymentType)
        {
            PaymentType = paymentType;
        }
        public string PaymentType { get; set; }
    }
}
