using MediatR;
using MediatRConfiguration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRConfiguration.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.Product);
            return Unit.Value;
        }
    }
}
