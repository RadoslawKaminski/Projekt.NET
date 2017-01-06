namespace Projekt.NET.Models
{
    public class Friend
    {
        public string FriendId { get; set; }
        public string Username { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}