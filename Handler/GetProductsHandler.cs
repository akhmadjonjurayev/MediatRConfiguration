using MediatR;
using MediatRConfiguration.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRConfiguration.Handler
{
    public class GetProductsHandler : IRequestHandler<GetProductsQueryCommand, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQueryCommand request, CancellationToken cancellationToken)
        => await _fakeDataStore.GetAllProduct();
    }
}
