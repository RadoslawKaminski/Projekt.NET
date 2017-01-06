namespace Projekt.NET.Models
{
    public class FamilyPerson
    {
		public string FamilyPersonId { get; set; }
		public string Username { get; set; }
		public Who? Who{ get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
    
    public enum Who 
    {
        Father,
        Mother,
        Sister,
        Brother,
        Husband,
        Wife,
    }
}