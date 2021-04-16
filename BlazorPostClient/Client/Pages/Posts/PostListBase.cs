using AutoMapper;
using BlazorPostClient.Client.Contracts;
using BlazorPostClient.Client.ViewModels;
using BlazorPostClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Pages.Posts
{
    public class PostListBase : ComponentBase
    {
        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<PostView> Posts { get; set; } = new();

        public List<Post> PostsDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            PostsDB = (await PostService.GetAll()).ToList();

            Mapper.Map(PostsDB, Posts);
        }

    }
}
