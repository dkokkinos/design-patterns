using System;

namespace Mediator.CQRS
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public object Execute(CreateProductCommand command)
        {
            // In this command we change the state of the application 
            // by updating an existing product
            Console.WriteLine("Creating the product " + command.Name);
            return true;
        }
    }
}
