using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ITopicRepository : IDisposable
    {
        IEnumerable<Topic> GetAllTopics();
        Topic GetTopicById(int id);
        void RemoveTopic(int id);
        void AddTopic(Topic topic);
        void Save();
    }
}
