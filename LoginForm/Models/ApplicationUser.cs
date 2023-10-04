using Microsoft.AspNetCore.Identity;
namespace LoginForm.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Contactnumber { get; set; }
        public string Suburb { get; set; }
        public int Postcode { get; set; }

    }
}
