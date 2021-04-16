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
    public class AddPostBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<AuthorView> Authors { get; set; } = new List<AuthorView>();

        public List<Author> AuthorsDB { get; set; } = new List<Author>();

        public PostView Post { get; set; } = new();

        public Post PostDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AuthorsDB = (await AuthorService.GetAll()).ToList();

            Mapper.Map(AuthorsDB, Authors);
        }

        protected async Task CreatePost()
        {
            Mapper.Map(Post, PostDB);

            var post = await PostService.AddEntity(PostDB);

            if (post != null)
            {
                NavigationManager.NavigateTo("postList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("postList");
        }
    }
}
