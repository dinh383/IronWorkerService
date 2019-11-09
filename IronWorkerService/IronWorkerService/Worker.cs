using System;
using System.Threading;
using System.Threading.Tasks;
using IronWorkerService.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IronWorkerService
{
    //All background service inherit of BackgroundService and this latter implements IHostedService
    //IHostedService declares: StartAsync(CancellationToken) & StopAsync(CancellationToken)
    //BackgroundService adds: ExecuteAsync(CancellationToken)
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmailService _emailService;

        public Worker(ILogger<Worker> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
            _logger.LogInformation("_emailService {0}", _emailService.GetHashCode());
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Service started");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Service stopped");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker Service running");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Sending Pending Emails at: {time}", DateTimeOffset.Now);

                _emailService.SendPendingEmails();

                await Task.Delay(3 * 60 *1000, stoppingToken);
            }
        }
    }
}
