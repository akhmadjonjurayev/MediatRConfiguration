using MediatR;
using MediatRConfiguration.Data;
using System.Collections.Generic;

namespace MediatRConfiguration.Handler
{
    public record GetProductsQueryCommand() : IRequest<IEnumerable<Product>>;

    public record AddProductCommand(Product Product) : IRequest;

    public record GetproductByIdCommand(int id) : IRequest<Product>;
}
