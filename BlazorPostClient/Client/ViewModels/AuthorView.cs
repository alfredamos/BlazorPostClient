using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.ViewModels
{
    public class AuthorView
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }     
        public DateTime DateOfBirth { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
