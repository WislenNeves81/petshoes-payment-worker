using MassTransit;
using PetShoes.Payment.Worker.Core.Entities;
using PetShoes.Payment.Worker.Core.Services.Interface;

namespace PetShoes.Payment.Worker.Core.Consumers
{
    public class PurchaseOrderCreatedConsumer : IConsumer<PurchaseOrderCreatedEvent>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<PurchaseOrderCreatedConsumer> _logger;

        public PurchaseOrderCreatedConsumer(IServiceScopeFactory serviceScopeFactory, ILogger<PurchaseOrderCreatedConsumer> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PurchaseOrderCreatedEvent> context)
        {

            return Task.CompletedTask;

            //var paymentType = context.Message.PaymentType;
            //_logger.LogInformation($"Mensagem recebida: Tipo de pagamento = {paymentType}");

            //try
            //{
            //    using var scope = _serviceScopeFactory.CreateScope();
            //    var service = scope.ServiceProvider.GetRequiredService<IPayPurchaseOrder>();
            //    var result = await service.PayPurchaseOrderWithCreditCardAsync(paymentType);
            //    _logger.LogInformation($"Processamento do pagamento retornou: {result}");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Erro ao processar pagamento.");
            //}
        }
    }
}
