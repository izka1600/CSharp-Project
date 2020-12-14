using BookWarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Data.Repository
{
	public interface IRepository
	{
		Post GetPost(int id);
		List<Post> GetAllPosts(int id);
		void RemovePost(int id);
		void AddPost(Post post);
		void UpdatePost(Post post);

		Task<bool> SaveChangesAsync();
	}
}
