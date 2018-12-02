using hasslefreeAPI.Email;
using hasslefreeAPI.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Extension
{
    public static class SendGridExtensions
    {
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
