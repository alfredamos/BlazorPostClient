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
    public class EditPostBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public List<AuthorView> Authors { get; set; } = new List<AuthorView>();

        public List<Author> AuthorsDB { get; set; } = new List<Author>();

        public PostView Post { get; set; } = new();

        public Post PostDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AuthorsDB = (await AuthorService.GetAll()).ToList();
            PostDB = await PostService.GetById(Id);

            Mapper.Map(AuthorsDB, Authors);
            Mapper.Map(PostDB, Post);
        }

        protected async Task UpdatePost()
        {
            Mapper.Map(Post, PostDB);

            var post = await PostService.UpdateEntity(PostDB);

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
