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
        public String PetName { get; set; }
        public String PetBreed { get; set; }
        public int PetAge { get; set; }
        public String PetGender { get; set; }
        public string AddressDetails { get; set; } // New property for address details


    }
}
