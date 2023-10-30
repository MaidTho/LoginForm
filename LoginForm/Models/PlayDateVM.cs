using System.ComponentModel;

namespace LoginForm.Models
{
    public class PlayDateVM
    {
        public int Id { get; set; }
        [DisplayName(displayName: "name on invite")]
        public string UserCreator { get; set; }
        [DisplayName(displayName: "status")]
        public Boolean? PlayDateAccepted { get; set; }

        [DisplayName(displayName: "Playdate on ")]
        public DateTime DateForPlayDate { get; set; }

    }
}

