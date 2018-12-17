using MongoDB.Bson;

namespace vstaskmgr.Model
{
    public class Project
    {
        public Project()
        { }
        public Project(ObjectId id, string name, string coverImg, string desc = null, string[] taskLists = null, string[] members = null)
        {
            this.Id = id;
            this.Name = name;
            this.CoverImg = coverImg;
            this.Desc = desc;
            this.TaskLists = taskLists;
            this.Members = members;
        }
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CoverImg { get; set; }
        public string[] TaskLists { get; set; }
        public string[] Members { get; set; }
    }
}
