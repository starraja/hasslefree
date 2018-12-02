using Microsoft.AspNetCore.Identity;

namespace hasslefreeAPI.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public virtual Employee Employee { get; set; }
    }
}