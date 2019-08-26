using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.Constants;

namespace VueCrudSolution.Shared.Utils.Notification
{
    public interface INotifier
    {
        Task<string> ReadTemplate(MessageTypes messageType);
        Task SendAsync(string to, string subject, string body);
        Task SendManyAsync(List<string> to, string subject, string body);
    }
}
