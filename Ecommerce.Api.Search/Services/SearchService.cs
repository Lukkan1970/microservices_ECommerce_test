using Ecommerce.Api.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductsService productsService;
        private readonly ICustomersService customersService;

        public SearchService(IOrderService orderService, IProductsService productsService, ICustomersService customersService)
        {
            this.orderService = orderService;
            this.productsService = productsService;
            this.customersService = customersService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var customerResult = await customersService.GetCustomerAsync(customerId);
            var orderResult = await orderService.GetOrdersAsync(customerId);
            var productResult = await productsService.GetProductsAsync();

            if (orderResult.IsSucces)
            {
                foreach (var order in orderResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productResult.IsSuccess ?
                                                productResult.Products.FirstOrDefault(p => p.Id == item.Id)?.Name :
                                                "No name";
                    }
                }

                var result = new
                {
                    Customer = customerResult.IsSuccess ?
                                customerResult.Customer :
                                new { Name = "Not available" },
                    Orders = orderResult.Orders

                };

                return (true, result);
            }

            return (false, null);
        }
    }
}
