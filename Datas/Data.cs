using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vstaskmgr.Model;

namespace vstaskmgr.Datas
{
    public class Data
    {
        private void AddQuote()
        {
            var document1 = new BsonDocument
            {
                { "Cn",   "我突然就觉得自己像个华丽的木偶,演尽了所有的悲欢离合,可是背上总是有无数闪亮的银色丝线,操纵我哪怕一举手一投足。" },
                { "En",    "I suddenly feel myself like a doll,acting all kinds of joys and sorrows.There are lots of shining silvery thread on my back,controlling all my action." },
                { "Pic",  "/assets/img/quotes/0.jpg" }
            };

            var document2 = new BsonDocument
            {
                { "Cn",    "被击垮通常只是暂时的，但如果你放弃的话，就会使它成为永恒。（Marilyn vos Savant）" },
                { "En",  "Being defeated is often a temporary condition. Giving up is what makes it permanent." },
                { "Pic",  "/assets/img/quotes/1.jpg" }
            };


            var document3 = new BsonDocument
            {
                { "Cn",  "不要只因一次挫败，就放弃你原来决心想达到的梦想。（莎士比亚）" },
                { "En",   "Do not, for one repulse, forgo the purpose that you resolved to effect." },
                { "Pic",  "/assets/img/quotes/2.jpg" }
            };
        }

        private void Project()
        {
            var project1 = new BsonDocument
            {
                { "Name",   "企业协作平台" },
                { "Desc",    "这是一个企业内部项目" },
                { "CoverImg",  "assets/img/covers/0.jpg" },
                { "Members", new BsonArray{"BkkDvwee-", "3", "4"} }
            };

            var project2 = new BsonDocument
            {
                { "Name",   "自动化测试项目" },
                { "Desc",    "这是一个企业内部项目"},
                { "CoverImg",  "assets/img/covers/1.jpg" },
                { "Members", new BsonArray{ "BkkDvwee-", "4", "37489e0c-df34-c261-71c4-ce75357e3035" } }
            };
            List<BsonDocument> list = new List<BsonDocument>();
            list.Add(project1);
            list.Add(project2);

            DBUtility.MongoDbHelper.AddCollection("project");
            DBUtility.MongoDbHelper.InsertAll("project", list);
        }

        private void User()
        {
            var user1 = new BsonDocument
            {
                { "Email", "lisi@163.com" },
                { "Password",   "Ls123456" },
                { "Name",    "李四" },
                { "Avatar",  "avatars:svg-2" },
                { "ProjectIds", new BsonArray{"1", "2"} }
            };

            var user2 = new BsonDocument
            {
                { "Email", "zhangsan@163.com" },
                { "Password",   "Ls123456" },
                { "Name",    "张三" },
                { "Avatar",  "avatars:svg-3" },
                { "ProjectIds", new BsonArray{"1", "2"} }
            };

            var user3 = new BsonDocument
            {
                { "Email", "liming@163.com" },
                { "Password",   "Ls123456" },
                { "Name",    "李明" },
                { "Avatar",  "avatars:svg-5" },
                { "ProjectIds", new BsonArray{"1"} }
            };

            List<BsonDocument> list = new List<BsonDocument>();
            list.Add(user1);
            list.Add(user2);
            list.Add(user3);

            DBUtility.MongoDbHelper.AddCollection("user");
            DBUtility.MongoDbHelper.InsertAll("user", list);
        }
    }
}
