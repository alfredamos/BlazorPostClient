﻿using AutoMapper;
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
    public class AuthorListBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<AuthorView> Authors { get; set; } = new List<AuthorView>();

        public List<Author> AuthorsDB { get; set; } = new List<Author>();

        protected async override Task OnInitializedAsync()
        {
            AuthorsDB = (await AuthorService.GetAll()).ToList();

            Mapper.Map(AuthorsDB, Authors);
        }


    }
}
