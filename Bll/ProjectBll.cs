using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using vstaskmgr.Model;

namespace vstaskmgr.Bll
{
    public class ProjectBll
    {
        public List<Project> GetProjectList(string members_like)
        {
            //var filter = Builders<Project>.Filter.Eq("members", members_like);
            var filter = new BsonDocument { { "Members", members_like } };
            return DBUtility.MongoDbHelper.GetList<Project>("project", filter);
        }

        public Project GetProjectById(string id)
        {
            var docId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == docId);
            return DBUtility.MongoDbHelper.GetOne<Project>("project", filter);
        }
    }
}
