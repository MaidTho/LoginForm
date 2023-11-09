using System.ComponentModel;

namespace LoginForm.Models
{
    public class PlayDateVM
    {
        public int Id { get; set; }

        [DisplayName(displayName: "Playdate title:")]
        public string PDTitle { get; set; }

        [DisplayName(displayName: "Current status:")]
        public Boolean? PlayDateAccepted { get; set; }

        [DisplayName(displayName: "Date:")]
        public DateTime DateForPlayDate { get; set; }

        [DisplayName(displayName: "Date:")]
        public DateTime DateCreated { get; set; }


    }
}

