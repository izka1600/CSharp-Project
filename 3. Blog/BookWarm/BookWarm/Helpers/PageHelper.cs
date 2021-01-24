using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWarm.Helpers
{
	public static class PageHelper
	{
		public static IEnumerable<int> PageNumbers(int pageNumber, int pageCount)
		{
			if (pageCount <= 5)
			{
				for (int i = 1; i <= pageCount; i++)
				{
					yield return i;
					//pages.Add(i);
				}
			}
			else
			{

				int midPoint = pageNumber;
				if (midPoint < 3)
				{
					midPoint = 3;
				}
				else if (midPoint > pageCount - 2)
				{
					midPoint = pageCount - 2 > 3 ? pageCount - 2 : 3;
				}

				int lowerBound = midPoint - 2;
				int upperBound = midPoint + 2;

				if (lowerBound != 1)
				{
					// pages.Insert(0, 1);
					yield return 1;
					if (lowerBound - 1 > 1)
					{
						//pages.Insert(1, -1);
						yield return -1;
					}
				}

				for (int i = lowerBound; i <= upperBound; i++)
				{
					yield return i;
					//pages.Add(i);
				}

				if (upperBound < pageCount)
				{
					//pages.Insert(pages.Count, pageCount);
					if (pageCount - upperBound > 1)
					{
						//pages.Insert(pages.Count - 1, -1);
						yield return -1;
					}
					yield return pageCount;
				}
			}
		}
	}
}
