using AutoMapper;
using BlazorPostClient.Client.Contracts;
using BlazorPostClient.Client.Shared.UI;
using BlazorPostClient.Client.ViewModels;
using BlazorPostClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Pages.Posts
{
    public class DeletePostBase : ComponentBase
    {
        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public PostView Post { get; set; } = new();

        public Post PostDB { get; set; } = new();

        public string PostAuthorName { get; set; }

        public string PostAuthorPhoto { get; set; }

        public int PostAuthorID { get; set; }

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            PostDB = await PostService.GetById(Id);

            PostAuthorName = PostDB.Author.FullName;
            PostAuthorPhoto = PostDB.Author.PhotoPath;
            PostAuthorID = PostDB.Author.AuthorID;

            Mapper.Map(PostDB, Post);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeletePost(bool deleteConfirmed)
        {
            Mapper.Map(Post, PostDB);

            if (deleteConfirmed)
            {
                await PostService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("postList");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("postList");
        }

    }
}
