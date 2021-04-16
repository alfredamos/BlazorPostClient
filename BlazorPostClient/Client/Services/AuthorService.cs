using BlazorPostClient.Client.Contracts;
using BlazorPostClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/authors";

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Author> AddEntity(Author newService)
        {
            return await _httpClient.PostJsonAsync<Author>(_baseUrl, newService);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Author[]>(_baseUrl);
        }

        public async Task<Author> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Author>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Author>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Author[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Author> UpdateEntity(Author updatedService)
        {
            return await _httpClient.PutJsonAsync<Author>($"{_baseUrl}/{updatedService.AuthorID}", updatedService);
        }
    }
}
