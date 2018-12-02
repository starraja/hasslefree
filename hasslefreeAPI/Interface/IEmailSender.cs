using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Interface
{
    public interface IEmailSender
    {
       
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details);
    }
}
