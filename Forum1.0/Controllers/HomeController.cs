using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using DataAccessLayer.DataModels;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Forum1._0.Models;

namespace Forum1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private ApplicationUserManager _userManager;

        public HomeController()
        {
            ForumDbContext dbContext = new ForumDbContext();
            _topicRepository = new TopicRepository(dbContext);
            _postRepository = new PostRepository(dbContext);
        }

        public HomeController(TopicRepository topicRepository, PostRepository postRepository, ApplicationUserManager userManager)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var topics = _topicRepository.GetAllTopics();
            return View(topics);
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult NewTopic()
        {
            TopicViewModel newTopic = new TopicViewModel();
            return View(newTopic);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewTopic(TopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                var today = DateTime.Now;
                var user = UserManager.FindById(User.Identity.GetUserId());

                Topic newTopic = new Topic()
                {
                    TopicName = topic.TopicName,
                    TopicDescription = topic.TopicDescription,
                    User = user,
                    TopicDateTime = today
                };

                _topicRepository.AddTopic(newTopic);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult OpenTopic(int id)
        {
            var posts = _postRepository.GetPostsByTopicId(id);

            List<PostViewModel> postsView = new List<PostViewModel>();
            foreach (var post in posts)
            {
                PostViewModel postView = new PostViewModel()
                {
                    PostId = post.Id,
                    PostAuthor = post.User.Email,
                    PostTitle = post.Title,
                    PostCreatedDate = post.PostedDate
                };
                postsView.Add(postView);
            }

            var topic = _topicRepository.GetTopicById(id);
            TopicDetailsViewModel topicDetail = new TopicDetailsViewModel()
            {
                TopicId = topic.Id,
                UserId = topic.User.Id,
                TopicName = topic.TopicName,
                Posts = postsView
            };

            return View(topicDetail);
        }

        [Authorize]
        [HttpGet]
        public ActionResult NewPost(int topicId)
        {
            PostDetailsViewModel newPost = new PostDetailsViewModel()
            {
                TopicId = topicId
            };
            return View(newPost);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewPost(PostDetailsViewModel newPostDetail)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post()
                {
                    Title = newPostDetail.PostTitle,
                    Text = newPostDetail.PostText,
                    User = UserManager.FindById(User.Identity.GetUserId()),
                    UserId = User.Identity.GetUserId(),
                    PostedDate = DateTime.Now,
                    Topic = _topicRepository.GetTopicById(newPostDetail.TopicId),
                    TopicId = newPostDetail.TopicId
                };
                _postRepository.AddPost(post);
                return RedirectToAction("OpenTopic");
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult ReadPost(int id)
        {
            Post post = _postRepository.GetPostById(id);
            if (post != null)
            {
                PostDetailsViewModel postView = new PostDetailsViewModel(post);
                return View(postView);
            }

            return View("Error");
        }
    }
}