using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
//此外，你将频繁的用到下面这些 using 语句中的一条或多条: 
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace vstaskmgr.DBUtility
{
    public class MongoDbHelper
    {

        // public static readonly string connectionString = "mongodb+srv://Haixiao:123321@cluster0-eiagv.mongodb.net/test?retryWrites=true";
        // public static readonly string database ;

        private readonly IMongoDatabase _database;

        public MongoDbHelper(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TaskmgrDb"));
            _database = client.GetDatabase("taskmgr");
        }

        #region 表操作
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="collectionName"></param>
        public void AddCollection(string collectionName)
        {
            _database.CreateCollection(collectionName);
        }
        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="collectionName"></param>
        public void DeleteCollection(string collectionName)
        {
            _database.DropCollection(collectionName);
        }
        #endregion

        #region 新增
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entiry"></param>
        public void InsertOne<T>(string collectionName, T entity) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.InsertOne(entity);
        }
        /// <summary>
        /// 插入多个数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entiry"></param>
        public void InsertAll<T>(string collectionName, IEnumerable<T> entity) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.InsertMany(entity);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 替换操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="query">条件</param>
        /// <param name="entry">新实体</param>
        public void Update<T>(string collectionName, T entity, FilterDefinition<T> query) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.ReplaceOne(query, entity);
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="query">条件</param>
        /// <param name="entry">更新内容实体</param>
        public void Update<T>(string collectionName, UpdateDefinition<T> entity, FilterDefinition<T> query) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.UpdateOne(query, entity);
        }
        
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="query">条件</param>
        /// <param name="entry">新实体</param>
        public void UpdateAll<T>(string collectionName, BsonDocument entity, BsonDocument query) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.UpdateMany(entity, query);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetOne<T>(string collectionName, FilterDefinition<T> query) where T : class
        {
            T result = default(T);
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            result = categories.Find(query).FirstOrDefault();
            return result;
        }
        /*
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T GetOne<T>(string collectionName, BsonDocument query, BsonDocument fields) where T : class
        {
            T result = default(T);
            using (Mongo mongo = new Mongo(connectionString))
            {
                mongo.Connect();
                IMongoDatabase friends = mongo.GetDatabase(database);
                IMongoCollection<T> categories = friends.GetCollection<T>(collectionName);
                result = categories.Find(query, fields).Skip(0).Limit(1).Documents.First();
                mongo.Disconnect();

            }
            return result;
        }
        */
        /// <summary>
        /// 获取一个集合下所有数据
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public List<T> GetAll<T>(string collectionName) where T : class
        {
            List<T> result = new List<T>();
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            result = categories.Find(new BsonDocument()).ToList();
            return result;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string collectionName, FilterDefinition<T> selector) where T : class
        {
            List<T> result = new List<T>();
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            result = categories.Find(selector).ToList();
            return result;
        }
        /*
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <param name="Sort"></param>
        /// <param name="cp"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string collectionName, object selector, Document sort, int cp, int mp) where T : class
        {
            List<T> result = new List<T>();
            using (Mongo mongo = new Mongo(connectionString))
            {
                mongo.Connect();
                IMongoDatabase friends = mongo.GetDatabase(database);
                IMongoCollection<T> categories = friends.GetCollection<T>(collectionName);
                foreach (T entity in categories.Find(selector).Sort(sort).Skip((cp - 1) * mp).Limit(mp).Documents)
                {
                    result.Add(entity);
                }
                mongo.Disconnect();

            }
            return result;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <param name="Sort"></param>
        /// <param name="cp"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string collectionName, object selector, object fields, Document sort, int cp, int mp) where T : class
        {
            List<T> result = new List<T>();
            using (Mongo mongo = new Mongo(connectionString))
            {
                mongo.Connect();
                IMongoDatabase friends = mongo.GetDatabase(database);
                IMongoCollection<T> categories = friends.GetCollection<T>(collectionName);
                foreach (T entity in categories.Find(selector, fields).Sort(sort).Skip((cp - 1) * mp).Limit(mp).Documents)
                {
                    result.Add(entity);
                }
                mongo.Disconnect();

            }
            return result;
        }
        */
        #endregion


        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entity"></param>
        public void DeleteOne<T>(string collectionName, FilterDefinition<T> query) where T : class
        {
            IMongoCollection<T> categories = _database.GetCollection<T>(collectionName);
            categories.DeleteOne(query);
        }
        #endregion
    }
}
