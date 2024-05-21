using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Api.ProductCatalog.Model;
using ECommerce.Api.ProductCatalog.Persistence;

namespace ECommerce.Api.ProductCatalog.Aplication
{
    public class Query
    {
        public class Execute : IRequest<List<ProductDto>> {
           
        }

        public class Manager : IRequestHandler<Execute, List<ProductDto>>
        {
            private readonly ContextProduct _context;
            private readonly IMapper _mapper;

            public Manager(ContextProduct context, IMapper mapper) {
                _context = context;
                _mapper = mapper;

            }
            
            public async Task<List<ProductDto>> Handle(Execute request, CancellationToken cancellationToken)
            {          
                    var libros = await _context.Products.ToListAsync();
                    var librosDto = _mapper.Map<List<Product>, List<ProductDto>>(libros);
                    return librosDto;                                         
            }
        }

    }
}