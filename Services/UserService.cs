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
        private readonly MongoDbHelper _mongoDbHelper;

        public UserService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public User GetLoginUser(string email, string password)
        {
            var filter = new BsonDocument { { "Email", email }, { "Password", password } };
            User user = _mongoDbHelper.GetOne<User>("user", filter);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _mongoDbHelper.GetAll<User>("user");
        }

        public User GetProjectById(string id)
        {
            var userId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<User>(project => project.Id == userId);
            return _mongoDbHelper.GetOne<User>("user", filter);
        }
    }
}
