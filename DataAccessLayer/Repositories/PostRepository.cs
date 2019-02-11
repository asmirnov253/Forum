using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Contexts;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _dbContext;

        public PostRepository(ForumDbContext context)
        {
            _dbContext = context;
        }

        public void AddPost(Post post)
        {
            _dbContext.Entry(post).State = EntityState.Added;
            Save();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _dbContext.Posts.Include(p => p.User).ToList();
        }

        public IEnumerable<Post> GetPostsByTopicId(int topicId)
        {
            return _dbContext.Posts.Where(p => p.TopicId == topicId).ToList();
        }

        public Post GetPostById(int id)
        {
           return _dbContext.Posts.Where(p => p.Id == id).Include(p => p.User).SingleOrDefault();
        }

        public void RemovePost(int id)
        {
            Post post = _dbContext.Posts.Find(id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
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
