using System.ComponentModel;

namespace LoginForm.Models
{
    public class ApplicationUserVM
    {
        [DisplayName(displayName: "User Name:")]
        public string FirstName { get; set; }

        [DisplayName(displayName: "Last Name:")]
        public string Surname { get; set; }

        [DisplayName(displayName: "Contact Number:")]
        public int Contactnumber { get; set; }

        [DisplayName(displayName: "Suburb:")]
        public string Suburb { get; set; }

        [DisplayName(displayName: "Petname")]
        public String PetName { get; set; }

        [DisplayName(displayName: "Breed:")]
        public String PetBreed { get; set; }



    }
}

