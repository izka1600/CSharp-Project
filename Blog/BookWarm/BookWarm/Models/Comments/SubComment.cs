using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Models.Comments
{
	public class SubComment:Comment
	{
		public int MainCommentId  { get; set; }
	}
}
