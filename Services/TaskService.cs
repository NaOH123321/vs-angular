using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using vstaskmgr.DBUtility;
using vstaskmgr.Model;

namespace vstaskmgr.Services
{
    public class TaskService
    {
        private readonly string _collectrionName = "task";
        private readonly MongoDbHelper _mongoDbHelper;

        public TaskService(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public List<Task> Get()
        {
            return _mongoDbHelper.GetAll<Task>(_collectrionName);
        }

        public List<Task> GetByOwnerId(string ownerId)
        {
            var filter = new BsonDocument { { "OwnerId", ownerId } };
            return _mongoDbHelper.GetList<Task>(_collectrionName, filter);
        }

        public List<Task> GetByTaskListId(string taskListId)
        {
            var filter = new BsonDocument { { "TaskListId", taskListId } };
            return _mongoDbHelper.GetList<Task>(_collectrionName, filter);
        }

        public Task Get(string id)
        {
            var taskListId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Task>(taskList => taskList.Id == taskListId);
            return _mongoDbHelper.GetOne<Task>(_collectrionName, filter);
        }

        public Task Create(Task task)
        {
            _mongoDbHelper.InsertOne<Task>(_collectrionName, task);
            return task;
        }

        public void Update(string id, Task taskIn)
        {
            var update = Builders<Task>.Update;
            var updates = new List<UpdateDefinition<Task>>();

            if (taskIn.Desc != null)
                updates.Add(update.Set("Desc", taskIn.Desc));

            if (taskIn.Priority != 0)
                updates.Add(update.Set("Priority", taskIn.Priority));

            if (taskIn.DueDate != null)
                updates.Add(update.Set("DueDate", taskIn.DueDate));

            if (taskIn.Reminder != null)
                updates.Add(update.Set("Reminder", taskIn.Reminder));

            if (taskIn.Remark != null)
                updates.Add(update.Set("Remark", taskIn.Remark));

            if (taskIn.OwnerId != null)
                updates.Add(update.Set("OwnerId", taskIn.OwnerId));

            if (taskIn.ParticipantIds != null)
                updates.Add(update.Set("ParticipantIds", taskIn.ParticipantIds));

            if (taskIn.Completed)
                updates.Add(update.Set("Completed", taskIn.Completed));

            if (taskIn.TaskListId != null)
                updates.Add(update.Set("TaskListId", taskIn.TaskListId));

            var taskId = new ObjectId(id);
            var filter = new ExpressionFilterDefinition<Task>(task => task.Id == taskId);
            _mongoDbHelper.Update<Task>(_collectrionName, update.Combine(updates), filter);
        }

        public void Remove(Task taskIn)
        {
            var filter = new ExpressionFilterDefinition<Task>(taskList => taskList.Id == taskIn.Id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }

        public void Remove(ObjectId id)
        {
            var filter = new ExpressionFilterDefinition<Task>(taskList => taskList.Id == id);
            _mongoDbHelper.DeleteOne(_collectrionName, filter);
        }
    }
}