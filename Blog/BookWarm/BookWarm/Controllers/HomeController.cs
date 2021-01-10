﻿using BookWarm.Data;
using BookWarm.Data.FileManager;
using BookWarm.Data.Repository;
using BookWarm.Models;
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

        public IActionResult Index(string category) =>
            View(string.IsNullOrEmpty(category) ? 
                _repo.GetAllPosts() : 
                _repo.GetAllPosts(category));

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
        public IActionResult Image(string image) =>
            new FileStreamResult(
                _fileManager.ImageStream(image), 
                $"image/{image.Substring(image.LastIndexOf('.') + 1)}"
                );
		

    }
}
