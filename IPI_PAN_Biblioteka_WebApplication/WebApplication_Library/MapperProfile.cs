using System;
using AuthDatabase.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Library.Models;
using WebApplication_Library.Services;


namespace WebApplication_Library
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<NewBookViewModel,NewBook>().ReverseMap();
			CreateMap<ListBookViewModel, BookViewModel>().ReverseMap();
            CreateMap<WebApplication_Library.Services.Book, BookViewModel>();
            CreateMap<DateTimeOffset, DateTime>();
        }
	}
}
