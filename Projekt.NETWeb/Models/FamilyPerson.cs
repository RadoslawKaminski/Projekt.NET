namespace Projekt.NET.Models
{
    public class FamilyPerson
    {
		public int FamilyPersonId { get; set; }
		public string Username { get; set; }
		public Who Who{ get; set; }
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