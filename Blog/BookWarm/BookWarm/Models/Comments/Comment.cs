using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Models.Comments
{
	public class Comment
	{
		[Key]
		public int Id { get; set; }
		public string Message { get; set; }
		public DateTime Created { get; set; }
	}
}
