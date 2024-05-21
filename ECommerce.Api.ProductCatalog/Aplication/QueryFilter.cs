using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Api.ProductCatalog.Model;
using ECommerce.Api.ProductCatalog.Persistence;

namespace ECommerce.Api.ProductCatalog.Aplication
{
    public class QueryFilter
    {

        public class ProductUnique : MediatR.IRequest<ProductDto> { 
            public Guid? ProductId { get; set; }
        }

        public class Manager : IRequestHandler<ProductUnique, ProductDto>
        {
            private readonly ContextProduct _context;
            private readonly IMapper _mapper;

            public Manager(ContextProduct context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductDto> Handle(ProductUnique request, CancellationToken cancellationToken)
            {
                var libro = await _context.Products.Where(x => x.Id == request.ProductId).FirstOrDefaultAsync();
                if (libro == null) {
                    throw new Exception("The product was not found");
                }

                var libroDto = _mapper.Map<Product, ProductDto>(libro);
                return libroDto;
            }
        }

    }
}
