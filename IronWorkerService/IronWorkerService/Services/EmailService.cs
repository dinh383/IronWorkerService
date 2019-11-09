using IronWorkerService.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IronWorkerService.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly ISenderService _senderService;

        private static IList<Email> EmailsDataSource = new List<Email>
        {
            new Email(1, "Hello 1", "receiver1@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 1 !"),
            new Email(2, "Hello 2", "receiver2@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 2 !"),
            new Email(3, "Hello 3", "receiver3@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 3 !"),
            new Email(4, "Hello 4", "receiver4@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 4 !"),
            new Email(5, "Hello 5", "receiver5@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 5 !"),
            new Email(6, "Hello 6", "receiver6@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 6 !"),
            new Email(7, "Hello 7", "receiver7@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 7 !"),
            new Email(8, "Hello 8", "receiver8@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 8 !"),
            new Email(9, "Hello 9", "receiver9@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 9 !"),
            new Email(1, "Hello 10", "receiver10@fmoralesdev.com", "sender@fmoralesdev.com", "Hello world 10 !")
        };

        public EmailService(ILogger<EmailService> logger, ISenderService senderService)
        {
            _logger = logger;
            _senderService = senderService;
            _logger.LogInformation("senderService {0}", senderService.GetHashCode());
        }
        public void SendPendingEmails()
        {
            if (!ExistPendingEmails())
            {
                _logger.LogInformation("There are no pending emails");
                return;
            }

            var emailsToSend = GetEmailsToSend();
            _senderService.SendEmails(emailsToSend);

            _logger.LogInformation("Sent emails count: {0}", emailsToSend.Where(e => e.Status == eEmailStatus.Sent).Count());
        }

        private bool ExistPendingEmails()
        {
            return EmailsDataSource.Any(e => e.Status == eEmailStatus.PendingToSend);
        }

        private List<Email> GetEmailsToSend()
        {
            return EmailsDataSource.Where(e => e.Status == eEmailStatus.PendingToSend).ToList();
        }
    }
}
