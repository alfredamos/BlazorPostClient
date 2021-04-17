using BlazorPostClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.ViewModels
{
    public class PostView
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
       
        public int AuthorID { get; set; }
        public AuthorView Author { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string TruncatedContent
        {
            get
            {
                return $"{Content.Truncate(80)}{"...."}";
            }
        }
    }
}
