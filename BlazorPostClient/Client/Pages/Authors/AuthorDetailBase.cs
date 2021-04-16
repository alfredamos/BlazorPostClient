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

namespace BlazorPostClient.Client.Pages.Authors
{
    public class AuthorDetailBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public AuthorView Author { get; set; } = new AuthorView();

        public Author AuthorDB { get; set; } = new Author();

        protected async override Task OnInitializedAsync()
        {
            AuthorDB = await AuthorService.GetById(Id);

            Mapper.Map(AuthorDB, Author);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteAuthor(bool deleteConfirmed)
        {
            Mapper.Map(Author, AuthorDB);

            if (deleteConfirmed)
            {
                await AuthorService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("authorList");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("authorList");
        }
    }
}
