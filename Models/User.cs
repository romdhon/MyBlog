namespace Blogger.Models 
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserStat { get; set; }
        public int UserPosition { get; set; }
    }
}