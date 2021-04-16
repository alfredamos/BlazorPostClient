using AutoMapper;
using BlazorPostClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Server.Mappings
{
    public class Mapp : Profile
    {
        public Mapp()
        {
            CreateMap<Author, Author>();
            CreateMap<Post, Post>();
        }
    }
}
