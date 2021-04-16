using BlazorPostClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Client.Contracts
{
    public interface IPostService : IBaseService<Post>
    {
    }
}
