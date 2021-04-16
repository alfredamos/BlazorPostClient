using AutoMapper;
using BlazorPostClient.Client.Contracts;
using BlazorPostClient.Client.ViewModels;
using BlazorPostClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Pages.Authors
{
    public class EditAuthorBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public AuthorView Author { get; set; } = new AuthorView();

        public Author AuthorDB { get; set; } = new Author();

        protected async override Task OnInitializedAsync()
        {
            AuthorDB = await AuthorService.GetById(Id);

            Mapper.Map(AuthorDB, Author);
        }

        protected async Task UpdateAuthor()
        {
            Mapper.Map(Author, AuthorDB);

            var author = await AuthorService.UpdateEntity(AuthorDB);

            if (author != null)
            {
                NavigationManager.NavigateTo("authorList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("authorList");
        }
    }
}
