using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.DotNet.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.Constants;
using VueCrudSolution.Shared.Notification.Email;

namespace VueCrudSolution.Shared.Utils.Notification
{
    public class EmailNotification : INotifier
    {
        private readonly IEmailService _emailSvc;
        private readonly IHostingEnvironment _env;

        public EmailNotification(IEmailService emailSvc, IHostingEnvironment env)
        {
            _emailSvc = emailSvc;
            _env = env;
        }

        public Task<string> ReadTemplate(MessageTypes messageType)
        {
            string filepath = $@"{ApplicationEnvironment.ApplicationBasePath }App_Data\EmailNotifications";
            string htmlPath = $@"{filepath}\_template.html";
            string contentPath = $@"{filepath}\{messageType}.txt";
            string html = string.Empty;
            string body = string.Empty;

            // get global html template
            if (File.Exists(htmlPath))
                html = File.ReadAllText(htmlPath);
            else
                return null;

            // get specific message content
            if (File.Exists(contentPath))
                body = File.ReadAllText(contentPath);
            else return null;

            string msgBody = html.Replace("{body}", body);
            return Task.FromResult(msgBody);
        }

        //public Task<string> ReadTemplate(string key)
        //{
        //    string path = $@"{ApplicationEnvironment.ApplicationBasePath}App_Data\EmailNotifications\{key}";
        //    string body = string.Empty;
        //    if (File.Exists(path))
        //    {
        //        body = File.ReadAllText(path);
        //    }
        //    return Task.FromResult(body);
        //}

        public async Task SendAsync(string to, string subject, string body)
        {
            await _emailSvc.SendEmailAsync(subject, body, to);
        }

        public async Task SendManyAsync(List<string> to, string subject, string body)
        {
            await _emailSvc.SendManyEmailAsync(subject, body, to);
        }
    }
}
