using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Models
{
    public class SendGridResponseError
    {
        public string Message { get; set; }

        public string Field { get; set; }

        public string Help { get; set; }
    }
}
