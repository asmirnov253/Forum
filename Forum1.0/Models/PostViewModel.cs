
using System;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.DataModels;

namespace Forum1._0.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostAuthor { get; set; }
        public DateTime PostCreatedDate { get; set; }

        public PostViewModel()
        {
        }

        public PostViewModel(Post domainPost)
        {
            PostId = domainPost.Id;
            PostTitle = domainPost.Title;
            PostAuthor = domainPost.User.Email;
            PostCreatedDate = domainPost.PostedDate;
        }
    }
}