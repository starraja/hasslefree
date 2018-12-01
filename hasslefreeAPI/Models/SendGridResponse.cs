using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Models
{
    public class SendGridResponse
    {
        public List<SendGridResponseError> Errors { get; set; }
    }
}
