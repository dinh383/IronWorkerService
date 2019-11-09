using System;
using System.Collections.Generic;
using System.Text;

namespace IronWorkerService.Entities
{
    public class Email
    {
        public int EmailId { get; set; }
        public string Subject { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
        public eEmailStatus Status { get; set; }

        public Email(int emailId, string subject, string receiver, string sender, string body)
        {
            EmailId = emailId;
            Subject = subject;
            Receiver = receiver;
            Sender = sender;
            Body = body;
            Status = eEmailStatus.PendingToSend;
        }
    }
}
