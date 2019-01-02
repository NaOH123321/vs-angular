using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vstaskmgr.Model
{
    public class User
    {
        //public User()
        //{ }
        //public User(ObjectId id, string email, string name, string password, string avatar)
        //{
        //    this.Id = id;
        //    this.Email = email;
        //    this.Name = name;
        //    this.Password = password;
        //    this.Avatar = avatar;
        //}
        public ObjectId Id { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Avatar")]
        public string Avatar { get; set; }

        [BsonElement("ProjectIds")]
        public string[] ProjectIds { get; set; } = null;

        [BsonElement("address")]
        public Address address { get; set; }

        [BsonElement("identity")]
        public Identity identity { get; set; }

        [BsonElement("birthday")]
        public string birthday { get; set; }
    }
}
