using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Forum1._0.Models
{
    public class TopicDetailsViewModel
    {
        public int TopicId { get; set; }
        public string UserId { get; set; }

        [DisplayName("Title:")]
        public string TopicName { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}