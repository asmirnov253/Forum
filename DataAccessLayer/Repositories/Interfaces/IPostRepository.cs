using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPostRepository : IDisposable
    {
            IEnumerable<Post> GetAllPosts();
            IEnumerable<Post> GetPostsByTopicId(int topicId);
            Post GetPostById(int id);
            void RemovePost(int id);
            void AddPost(Post post);
            void Save();
    }
}
