using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vstaskmgr.Model
{
    public class Task
    {
        public ObjectId Id { get; set; }

        [BsonElement("Desc")]
        public string Desc { get; set; }

        [BsonElement("Completed")]
        public bool Completed { get; set; } = false;

        [BsonElement("Priority")]
        public int Priority { get; set; } = 0;

        [BsonElement("DueDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DueDate { get; set; } = null;

        [BsonElement("Reminder")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? Reminder { get; set; } = null;

        [BsonElement("Remark")]
        public string Remark { get; set; }

        [BsonElement("CreateDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreateDate { get; set; } = null;

        [BsonElement("OwnerId")]
        public string OwnerId { get; set; }

        [BsonElement("ParticipantIds")]
        public string[] ParticipantIds { get; set; } = null;

        [BsonElement("TaskListId")]
        public string TaskListId { get; set; }
    }
}
