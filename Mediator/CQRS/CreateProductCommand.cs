namespace Mediator.CQRS
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; }
        public decimal Price { get; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
