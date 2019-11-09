using IronWorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronWorkerService.Services
{
    public class SenderService : ISenderService
    {
        public void SendEmails(IList<Email> emails)
        {
            foreach (var email in emails)
            {

                if (emails.IndexOf(email) % 2 == 0)
                {
                    email.Status = eEmailStatus.Sent;
                }

            }
        }

    }
}
