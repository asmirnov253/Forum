using System;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.DataModels;

namespace Forum1._0.Models
{
    public class PostDetailsViewModel
    {
        public int PostId { get; set; }
        public int TopicId { get; set; }
        public string UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }
        public string PostAuthor { get; set; }
        public DateTime PostCreatedDate { get; set; }

        public PostDetailsViewModel()
        {
        }

        public PostDetailsViewModel(Post post)
        {
            PostId = post.Id;
            TopicId = post.TopicId;
            UserId = post.UserId;
            PostTitle = PostTitle;
            PostText = post.Text;
            PostAuthor = post.User.Email;
            PostCreatedDate = post.PostedDate;
        }
    }
}