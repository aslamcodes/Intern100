using System.ComponentModel.DataAnnotations;

namespace RequestTracker.Models.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        [Range(100, int.MaxValue, ErrorMessage = "Id is not valid")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
