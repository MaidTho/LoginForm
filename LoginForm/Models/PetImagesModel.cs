using System.ComponentModel.DataAnnotations;

namespace LoginForm.Models
{
    public class PetImagesModel
    {
        [Display(Name = "Choose the image of your pet")]
        [Required]

        public IFormFile? ImageOfPet { get; set; }
    }
}
