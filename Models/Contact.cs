using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Asp.netCore_MVC_.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [MinLength(3)]
        [MaxLength(128)]
        public string Name { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
