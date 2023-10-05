using System;
using System.Collections.Generic;

namespace Mediator.CQRS
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest>
    {
        public object Execute(GetProductsRequest requst)
        {
            // In this request we don't change any system state. We just return the products
            // from the database.
            Console.WriteLine("Return the products");
            return new List<object>() { new { Name = "product1" }, new { Name = "product2" } };
        }
    }
}
