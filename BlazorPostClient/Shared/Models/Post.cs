using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPostClient.Shared.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        [NotMapped]
        public string TruncatedContent 
        { 
            get
            {
                return $"{Content.Truncate(80)}{"...."}";
            } 
        }
    }
}
