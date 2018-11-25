using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace hasslefreeAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string UielementCode { get; }

        public PermissionAttribute(string uielementcode) : base("Permission")
        {
            UielementCode = uielementcode;
        }
    }
}
