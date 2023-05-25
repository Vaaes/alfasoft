using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace AlfaSoft.Models
{
    public class Contact
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        [MinLength(5, ErrorMessage = "Name must have at least 5 digits")]
        public string? Name { get; set; }
        [StringLength(9, ErrorMessage = "Contact must have 9 digits")]
        [MinLength(9, ErrorMessage = "Contact must have 9 digits")]
        [Required(ErrorMessage = "Contact is a required field")]
        public string? ContactPhone { get; set; }
        [Required(ErrorMessage = "Email is a required field")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public Contact()
        {
            ID = Guid.NewGuid();
        }

        public bool IsValid()
        {
            if (Name.Length < 5) { return false; }

            if (ContactPhone.Length != 9) { return false; }

            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
