using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTracker.Models
{
    public class User
    {
        [Key]
        public int EmployeeID { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        public string Status { get; set; }

    }
}
