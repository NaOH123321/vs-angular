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

            var document4 = new BsonDocument
            {
                { "Cn",    "想有发现就要实验，这项实验需要时间。—《神盾局特工》" },
                { "En",  "Discovery requires experimentation, and this experiment will take time." },
                { "Pic",  "/assets/img/quotes/3.jpg" }
            };


            var document5 = new BsonDocument
            {
                { "Cn",  "这世界并不会在意你的自尊，这世界希望你在自我感觉良好之前先要有所成就。" },
                { "En",   "The world won't care about your self-esteem. The world will expect you to accomplish something before you feel good about yourself." },
                { "Pic",  "/assets/img/quotes/4.jpg" }
            };

            var document6 = new BsonDocument
            {
                { "Cn",    "当你最终放开了过去，更好的事就会到来。" },
                { "En",  "When you finally let go of the past, something better comes along." },
                { "Pic",  "/assets/img/quotes/5.jpg" }
            };


            var document7 = new BsonDocument
            {
                { "Cn",  "我们学着放开过去伤害我们的人和事，学着只向前看。因为生活本来就是一往直前的。" },
                { "En",   "We learn to let go of things and people that hurt us in the past and just move on. For life is all about moving on." },
                { "Pic",  "/assets/img/quotes/6.jpg" }
            };

            var document8 = new BsonDocument
            {
                { "Cn",  "绝不要因为怕辛苦而拒绝一个想法、梦想或是目标，成功的路上难免伴随辛苦。（Bob Proctor）" },
                { "En",   "Never reject an idea, dream or goal because it will be hard work. Success rarely comes without it." },
                { "Pic",  "/assets/img/quotes/7.jpg" }
            };

            var document9 = new BsonDocument
            {
                { "Cn",  "我们在人生中会作出许多选择，带着这些选择继续生活，才是人生中最难的一课。《妙笔生花》" },
                { "En",   "We all make our choices in life. The hard thing to do is live with them." },
                { "Pic",  "/assets/img/quotes/8.jpg" }
            };

            var document10 = new BsonDocument
            {
                { "Cn",  "我总是对新的一天充满喜悦，这是一次新的尝试、一个新的开始，翘首以待，黎明之后或是惊喜。（约翰·博因顿·普里斯特利）" },
                { "En",   "I have always been delighted at the prospect of a new day, a fresh try, one more start, with perhaps a bit of magic waiting somewhere behind the morning." },
                { "Pic",  "/assets/img/quotes/9.jpg" }
            };

            List<BsonDocument> list = new List<BsonDocument>();
            list.Add(document4);
            list.Add(document5);
            list.Add(document6);
            list.Add(document7);
            list.Add(document8);
            list.Add(document9);
            list.Add(document10);

            DBUtility.MongoDbHelper.InsertAll("quote", list);
        }

        private void AddProject()
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

        private void AddUser()
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

        private void AddTaskList()
        {
            var taskList1 = new BsonDocument
            {
                { "Name",    "待办" },
                { "Order",  1 },
                { "ProjectId", "asds" }
            };

            var taskList2 = new BsonDocument
            {
                { "Name",    "进行中" },
                { "Order",  2 },
                { "ProjectId", "asds" }
            };

            var taskList3 = new BsonDocument
            {
                { "Name",    "待办" },
                { "Order",  1 },
                { "ProjectId", "ssss" }
            };

            var taskList4 = new BsonDocument
            {
                { "Name",    "进行中" },
                { "Order",  2 },
                { "ProjectId", "ssss" }
            };

            var taskList5 = new BsonDocument
            {
                { "Name",    "已完成" },
                { "Order",  3 },
                { "ProjectId", "ssss" }
            };

            List<BsonDocument> list = new List<BsonDocument>();
            list.Add(taskList1);
            list.Add(taskList2);
            list.Add(taskList3);
            list.Add(taskList4);
            list.Add(taskList5);

            DBUtility.MongoDbHelper.AddCollection("taskList");
            DBUtility.MongoDbHelper.InsertAll("taskList", list);
        }
    }
}
