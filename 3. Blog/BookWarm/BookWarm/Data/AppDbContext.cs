﻿using BookWarm.Models;
using BookWarm.Models.Comments;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Data
{
	public class AppDbContext:IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

		}
		public DbSet<Post> Posts { get; set; }
		public DbSet<MainComment> MainComments { get; set; }
		public DbSet<SubComment> SubComments { get; set; }
	}
}
