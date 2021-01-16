using BookWarm.Data;
using BookWarm.Data.FileManager;
using BookWarm.Data.Repository;
using BookWarm.Models;
using BookWarm.Models.Comments;
using BookWarm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWarm.Controllers
{
    public class HomeController : Controller 
    {
		private IRepository _repo;
		private IFileManager _fileManager;

		public HomeController(IRepository repo, IFileManager fileManager)
		{
            _repo = repo;
            _fileManager = fileManager;
		}
        //public IActionResult Index(string category)
        //{
        //   var posts = string.IsNullOrEmpty(category) ? _repo.GetAllPosts() : _repo.GetAllPosts(category);
        //   return View(posts); 
        //}

        public IActionResult Index(int pageNumber, string category)
        {
			if (pageNumber<0)
			{
                return RedirectToAction("Index", new { pageNumber = 0, category}); // tu wracamy do tej własnie akcji ale ze zmiana jednego parametru
			}

            var vm = _repo.GetAllPosts(pageNumber, category);

            return View(vm);
        }

        //public IActionResult Post(int id)
        //{
        //    var post = _repo.GetPost(id);
        //    return View(post);
        //}

        public IActionResult Post(int id) =>
            View(_repo.GetPost(id));

        //[HttpGet("/Image/{image}")]
        //public IActionResult Image(string image)
        //{
        //    var mime = image.Substring(image.LastIndexOf('.') + 1); //without dot
        //    return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        //}

        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image) =>
            new FileStreamResult(
                _fileManager.ImageStream(image), 
                $"image/{image.Substring(image.LastIndexOf('.') + 1)}"
                );

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
		{
			if (!ModelState.IsValid)
			{
                return RedirectToAction("Post", new { id = vm.PostId });
			}
            var post = _repo.GetPost(vm.PostId);
			if (vm.MainCommentId == 0)
			{
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now
                }) ;

                _repo.UpdatePost(post);
			}
			else
			{
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now
                };
                _repo.AddSubComment(comment);
			}

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });
        }
		
    }
}
