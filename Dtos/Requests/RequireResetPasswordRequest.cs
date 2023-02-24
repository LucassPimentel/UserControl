using System.ComponentModel.DataAnnotations;

namespace UserControl.Dtos.Requests
{
    public class RequireResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
