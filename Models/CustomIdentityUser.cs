using Microsoft.AspNetCore.Identity;

namespace UserControl.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
    }
}
