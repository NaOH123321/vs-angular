using MongoDB.Bson;

namespace vstaskmgr.Model
{
    public class User
    {
        public User()
        { }
        public User(ObjectId id, string email, string name, string password, string avatar)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.Password = password;
            this.Avatar = avatar;
        }
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string[] ProjectIds { get; set; } = null;
        public Address address { get; set; }
        public Identity identity { get; set; }
        public string birthday { get; set; }
    }
}
