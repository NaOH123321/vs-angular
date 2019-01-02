using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vstaskmgr.Model
{
    public class Quote
    {
        //public Quote()
        //{ }
        //public Quote(ObjectId id, string cn, string en, string pic)
        //{
        //    this.Id = id;
        //    this.Cn = cn;
        //    this.En = en;
        //    this.Pic = pic;
        //}
        public ObjectId Id { get; set; }

        [BsonElement("Cn")]
        public string Cn { get; set; }

        [BsonElement("En")]
        public string En { get; set; }

        [BsonElement("Pic")]
        public string Pic { get; set; }
    }
}
