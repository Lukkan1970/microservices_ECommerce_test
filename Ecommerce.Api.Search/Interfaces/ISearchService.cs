using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId);
    }
}
