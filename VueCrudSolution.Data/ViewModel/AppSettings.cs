using System;
using System.Collections.Generic;
using System.Text;

namespace VueCrudSolution.Data.ViewModel
{
    public class AppSettings
    {
        // Properties for JWT Token Signature
        public string Site { get; set; }
        public string Audience { get; set; }
        public string ExpireTime { get; set; }
        public string Secret { get; set; }

        // Email properties
        public string Username { get; set; }
        public string Password { get; set; }
        public AppSettings.EmailSetting EmailSettings { get; set; }

        public class EmailSetting
        {
            public string ApiKey { get; set; }
            public string Email { get; set; }
            public string FeedbackEmail { get; set; }
        }
    }
}
