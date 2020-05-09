using ECommerce.Api.Curtomers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Curtomers.Interfaces
{
    public  interface ICustomersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);


    }
}
