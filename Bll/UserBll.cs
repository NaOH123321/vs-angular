using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vstaskmgr.Model;

namespace vstaskmgr.Bll
{
    public class UserBll
    {
        public User GetLoginUser(string email, string password)
        {
            var filter = new BsonDocument { { "Email", email },{ "Password" , password} };
            User user = DBUtility.MongoDbHelper.GetOne<User>("user", filter);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return DBUtility.MongoDbHelper.GetAll<User>("user");
        }

        public User GetProjectById(string id)
        {
            var userId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<User>(project => project.Id == userId);
            return DBUtility.MongoDbHelper.GetOne<User>("user", filter);
        }
    }
}
