namespace LoginForm.Models
{
    public class PlayDate
    {
        public int ID { get; set; }

        public string UserCreator { get; set; }
        public string? PDTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateForPlayDate { get; set; }
        public Boolean? PlayDateAccepted { get; set; }

    }
}
