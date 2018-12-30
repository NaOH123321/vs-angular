using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class TaskListService
    {
        private readonly string _collectrionName = "taskList";
        private readonly MongoDbHelper _mongoDbHelper;

        public TaskListService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<TaskList> Get()
        {
            return _mongoDbHelper.GetAll<TaskList>(_collectrionName);
        }

        public List<TaskList> GetByProjectId(string projectId)
        {
            var filter = new BsonDocument { { "ProjectId", projectId } };
            return _mongoDbHelper.GetList<TaskList>(_collectrionName, filter);
        }

        public TaskList Get(string id)
        {
            var taskListId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<TaskList>(taskList => taskList.Id == taskListId);
            return _mongoDbHelper.GetOne<TaskList>(_collectrionName, filter);
        }

        public TaskList Create(TaskList taskList)
        {
            _mongoDbHelper.InsertOne<TaskList>(_collectrionName, taskList);
            return taskList;
        }

        public void Update(string id, TaskList taskListIn)
        {
            var update = Builders<TaskList>.Update;
            var updates = new List<UpdateDefinition<TaskList>>();

            if (taskListIn.Name != null)
                updates.Add(update.Set("Name", taskListIn.Name));

            if (taskListIn.Order != 0)
                updates.Add(update.Set("Order", taskListIn.Order));

            var taskListId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<TaskList>(taskList => taskList.Id == taskListId);
            _mongoDbHelper.Update<TaskList>(_collectrionName, update.Combine(updates), filter);
        }

        public void Remove(TaskList taskListIn)
        {
            var filter = new ExpressionFilterDefinition<TaskList>(taskList => taskList.Id == taskListIn.Id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }

        public void Remove(ObjectId id)
        {
            var filter = new ExpressionFilterDefinition<TaskList>(taskList => taskList.Id == id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }
    }
}