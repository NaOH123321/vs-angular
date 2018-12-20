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
    }
}
