using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class ProjectService
    {
        private readonly MongoDbHelper _mongoDbHelper;

        public ProjectService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }
        public List<Project> GetProjectList(string members_like)
        {
            //var filter = Builders<Project>.Filter.Eq("members", members_like);
            var filter = new BsonDocument { { "Members", members_like } };
            return _mongoDbHelper.GetList<Project>("project", filter);
        }

        public Project GetProjectById(string id)
        {
            var projectId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == projectId);
            return _mongoDbHelper.GetOne<Project>("project", filter);
        }
    }
}
