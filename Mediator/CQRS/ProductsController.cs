namespace Mediator.CQRS
{
    public class ProductsController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /product
        public void CreateProduct(string productName, decimal price)
        {
            _mediator.Send(new CreateProductCommand(productName, price));
        }

        // GET /products
        public object GetProducts()
        {
            return _mediator.Send(new GetProductsRequest());
        }
    }
}
