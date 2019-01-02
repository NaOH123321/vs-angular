using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class ProjectService
    {
        private readonly string _collectrionName = "project";
        private readonly MongoDbHelper _mongoDbHelper;

        public ProjectService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<Project> Get()
        {
            return _mongoDbHelper.GetAll<Project>(_collectrionName);
        }

        public List<Project> GetByUserId(string userId)
        {
            var filter = new BsonDocument { { "Members", userId } };
            return _mongoDbHelper.GetList<Project>(_collectrionName, filter);
        }

        public Project Get(string id)
        {
            var projectId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == projectId);
            return _mongoDbHelper.GetOne<Project>(_collectrionName, filter);
        }

        public Project Create(Project project)
        {
            _mongoDbHelper.InsertOne<Project>(_collectrionName, project);
            return project;
        }

        public void Update(string id, Project projectIn)
        {
            var update = Builders<Project>.Update;
            var updates = new List<UpdateDefinition<Project>>();

            if (projectIn.Name != null)
                updates.Add(update.Set("Name", projectIn.Name));

            if (projectIn.Desc != null)
                updates.Add(update.Set("Desc", projectIn.Desc));

            if (projectIn.CoverImg != null)
                updates.Add(update.Set("CoverImg", projectIn.CoverImg));

            if (projectIn.Members != null)
                updates.Add(update.Set("Members", projectIn.Members));

            var projectId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == projectId);
            _mongoDbHelper.Update<Project>(_collectrionName, update.Combine(updates), filter);
        }

        public void Remove(Project projectIn)
        {
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == projectIn.Id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }

        public void Remove(ObjectId id)
        {
            var filter = new ExpressionFilterDefinition<Project>(project => project.Id == id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }
    }
}
