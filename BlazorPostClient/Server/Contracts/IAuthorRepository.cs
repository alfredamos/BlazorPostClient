using BlazorPostClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPostClient.Server.Contracts
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
    }
}
