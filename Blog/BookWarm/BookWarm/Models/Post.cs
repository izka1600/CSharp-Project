﻿using System;

namespace BookWarm.Models
{
	public class Post
    {
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Body { get; set; } = "";
		public string Image { get; set; } = ""; //name of the file, because we know that is is stored in wwwroot/content
		public DateTime Created { get; set; } = DateTime.Now;

	}
}
