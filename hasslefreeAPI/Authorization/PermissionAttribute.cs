using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace hasslefreeAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionType PermissionType { get; }
        public int PermissionId { get; }

        public PermissionAttribute(PermissionType permissiontype,int permissionid) : base("Permission")
        {
            PermissionType = permissiontype;
            PermissionId = permissionid;
        }
    }
}
