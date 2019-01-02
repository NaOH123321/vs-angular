using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vstaskmgr.Model
{
    public class Project
    {
        //public Project()
        //{ }
        //public Project(ObjectId id, string name, string coverImg, string desc = null, string[] members = null)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.CoverImg = coverImg;
        //    this.Desc = desc;
        //    this.Members = members;
        //}
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Desc")]
        public string Desc { get; set; }

        [BsonElement("CoverImg")]
        public string CoverImg { get; set; }

        [BsonElement("Members")]
        public string[] Members { get; set; } = null;
    }
}
