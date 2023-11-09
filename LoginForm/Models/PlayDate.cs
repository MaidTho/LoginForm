namespace LoginForm.Models
{
    public class PlayDate
    {
        public int Id { get; set; }
        public string? UserCreator { get; set; }
        public string? PDTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public PlayDate()
        {
            DateCreated = DateTime.Now;
        }
        public DateTime DateForPlayDate { get; set; }
        public Boolean? PlayDateAccepted { get; set; }
        
    }
}
