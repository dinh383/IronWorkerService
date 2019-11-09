using System.Collections.Generic;
using IronWorkerService.Entities;

namespace IronWorkerService.Services
{
    public interface ISenderService
    {
        void SendEmails(IList<Email> emails);
    }
}