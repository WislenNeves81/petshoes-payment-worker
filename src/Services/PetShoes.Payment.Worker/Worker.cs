namespace PetShoes.Payment.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Servi�o Worker iniciado. O consumo de mensagens � gerenciado pelo MassTransit.");
            return Task.CompletedTask;
        }
    }
}
