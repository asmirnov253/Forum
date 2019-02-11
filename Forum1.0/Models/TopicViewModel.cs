using System.ComponentModel.DataAnnotations;

namespace Forum1._0.Models
{
    public class TopicViewModel
    {
        [Required]
        [StringLength(100)]
        public string TopicName { get; set; }

        public string TopicDescription { get; set; }
        public int PostsCount { get; set; }
    }
}