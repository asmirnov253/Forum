using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ForumDbContext _dbContext;

        public TopicRepository(ForumDbContext context)
        {
            _dbContext = context;
        }

        public void AddTopic(Topic topic)
        {
            if (topic != null)
            {
                _dbContext.Entry(topic.User).State = EntityState.Unchanged;
                _dbContext.Topics.Add(topic);
                Save();
            }
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _dbContext.Topics.Include("User").ToList();
        }

        public Topic GetTopicById(int id)
        {
            return _dbContext.Topics.Where(t => t.Id==id).Include(t => t.User).SingleOrDefault();
        }

        public void RemoveTopic(int id)
        {
            Topic topic = _dbContext.Topics.Find(id);
            if (topic != null)
            {
                _dbContext.Topics.Remove(topic);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
