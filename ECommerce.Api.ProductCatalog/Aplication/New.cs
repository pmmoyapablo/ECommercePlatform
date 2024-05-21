using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Api.ProductCatalog.Model;
using ECommerce.Api.ProductCatalog.Persistence;

namespace ECommerce.Api.ProductCatalog.Aplication
{
    public class New
    {
        public class Execute : IRequest {
          public Guid? Id { get; set; }

          public string Description { get; set; }

          public DateTime? DateCreated { get; set; }

          public string? Category { get; set; }

          public decimal Price { get; set; }

    }

        public class EjecutaValidacion : AbstractValidator<Execute> {

            public EjecutaValidacion() {
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.DateCreated).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
            }
        }


        public class Manejador : IRequestHandler<Execute>
        {
            private readonly ContextProduct _context;       
            public Manejador(ContextProduct context) {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {

                var product = new Product
                {
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    Category = request.Category,
                    Price = request.Price
                };

                _context.Products.Add(product);

                var value = await _context.SaveChangesAsync();

                if (value > 0) {
                    return Unit.Value;
                }

                throw new Exception("Product could not be created");
                
            }
        }

    }
}