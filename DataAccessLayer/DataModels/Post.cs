using System;

namespace DataAccessLayer.DataModels
{
    public class Post
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime PostedDate { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
        
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
    }
}
