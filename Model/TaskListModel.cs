using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vstaskmgr.Model
{
    public class TaskList
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Order")]
        public int Order { get; set; } = 0;

        [BsonElement("ProjectId")]
        public string ProjectId { get; set; }
    }
}
