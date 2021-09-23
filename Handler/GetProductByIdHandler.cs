using MediatR;
using MediatRConfiguration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRConfiguration.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetproductByIdCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(GetproductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _fakeDataStore.GetProductById(request.id);
            return await Task.FromResult(product);
        }
    }
}
