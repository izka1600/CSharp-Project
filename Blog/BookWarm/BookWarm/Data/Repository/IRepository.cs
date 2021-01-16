using BookWarm.Models;
using BookWarm.Models.Comments;
using BookWarm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Data.Repository
{
	public interface IRepository
	{
		Post GetPost(int id);
		List<Post> GetAllPosts();
		IndexViewModel GetAllPosts(int pageNumber, string Category);
		void RemovePost(int id);
		void AddPost(Post post);
		void UpdatePost(Post post);

		void AddSubComment(SubComment comment);

		Task<bool> SaveChangesAsync();
	}
}
