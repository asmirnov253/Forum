using System;
using System.Collections.Generic;

namespace DataAccessLayer.DataModels
{
    public class Topic
    {
        public int Id { get; set; }
        public String TopicName { get; set; }
        public String TopicDescription { get; set; }
        public DateTime TopicDateTime { get; set; }

        public List<Post> Posts { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
