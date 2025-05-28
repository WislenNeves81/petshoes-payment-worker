using PetShoes.Payment.Worker.Core.Services.Interface;

namespace PetShoes.Payment.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPayPurchaseOrder _payPurchaseOrder;


        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IDisposable _disposable;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, 
                        IPayPurchaseOrder payPurchaseOrder,
                        IServiceScopeFactory serviceScopeFactory,
                        IConfiguration configuration)
        {
            _logger = logger;
            _payPurchaseOrder = payPurchaseOrder;
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Serviço de {nameof(Worker)} iniciado.");

            //_disposable = _consumer.Start<Customer>(_configuration.GetSection("RabbitMq:QueueName").Value, async (message) =>
            //{
            //    await ProcessAsync()
            //            .ConfigureAwait(false);
            //});
        }

        private async Task ProcessAsync()
        {
            
            _logger.LogInformation($"Serviço de {nameof(Worker)} recebeu mensage do broker");

            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var service = scope
                                    .ServiceProvider
                                    .GetRequiredService<IPayPurchaseOrder>();

                    await service
                            .PayPurchaseOrderWithCreditCardAsync()
                            .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Serviço de {nameof(Worker)} com erro de execução => {ex.Message}.");
            }
        }
    }
}
