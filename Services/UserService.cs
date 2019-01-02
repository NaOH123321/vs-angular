using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class UserService
    {
        private readonly string _collectrionName = "user";
        private readonly MongoDbHelper _mongoDbHelper;

        public UserService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public User GetLoginUser(string email, string password)
        {
            var filter = new BsonDocument { { "Email", email }, { "Password", password } };
            User user = _mongoDbHelper.GetOne<User>(_collectrionName, filter);
            return user;
        }

        public List<User> Get()
        {
            return _mongoDbHelper.GetAll<User>(_collectrionName);
        }

        public List<User> GetByEmail(string email)
        {
            var filter = new BsonDocument { { "Email", email } };
            return _mongoDbHelper.GetList<User>(_collectrionName, filter);
        }

        public List<User> GetByProjectId(string projectId)
        {
            var filter = new BsonDocument { { "ProjectIds", projectId } };
            return _mongoDbHelper.GetList<User>(_collectrionName, filter);
        }

        public User Get(string id)
        {
            var userId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<User>(user => user.Id == userId);
            return _mongoDbHelper.GetOne<User>(_collectrionName, filter);
        }

        public User Create(User user)
        {
            _mongoDbHelper.InsertOne<User>(_collectrionName, user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            var update = Builders<User>.Update;
            var updates = new List<UpdateDefinition<User>>();

            if (userIn.ProjectIds != null)
                updates.Add(update.Set("ProjectIds", userIn.ProjectIds));

            var userId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<User>(user => user.Id == userId);
            _mongoDbHelper.Update<User>(_collectrionName, update.Combine(updates), filter);
        }

        public void Remove(User userIn)
        {
            var filter = new ExpressionFilterDefinition<User>(user => user.Id == userIn.Id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }

        public void Remove(ObjectId id)
        {
            var filter = new ExpressionFilterDefinition<User>(user => user.Id == id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }
    }
}
