using AutoMapper;
using BlazorPostClient.Client.ViewModels;
using BlazorPostClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Mapings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Author, AuthorView>().ReverseMap();
            CreateMap<Post, PostView>().ReverseMap();
        }
    }
}
