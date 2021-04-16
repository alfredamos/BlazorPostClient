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
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/posts";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Post> AddEntity(Post newService)
        {
            return await _httpClient.PostJsonAsync<Post>(_baseUrl, newService);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Post[]>(_baseUrl);
        }

        public async Task<Post> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Post>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Post>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Post[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Post> UpdateEntity(Post updatedService)
        {
            return await _httpClient.PutJsonAsync<Post>($"{_baseUrl}/{updatedService.PostID}", updatedService);
        }
    }
}
