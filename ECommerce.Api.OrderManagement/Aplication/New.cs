using MediatR;
using ECommerce.Api.OrderManagement.Model;
using ECommerce.Api.OrderManagement.Persistence;

namespace ECommerce.Api.OrderManagement.Aplication
{
    public class New
    {
        public class Execute : IRequest { 
            public DateTime DateRegisterSession { get; set; }

            public List<CarDetailDto>? ProductsList { get; set; }
        }
     
        public class Manejador : IRequestHandler<Execute>
        {
            private readonly CarContext _context;
            public Manejador(CarContext context) {
                _context = context;
            }
            
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var total = GetPriceTotal(request.ProductsList!);

                var carSession = new CarSession
                {
                   DateRegister = request.DateRegisterSession,
                   Total = total
                };

                _context.CarSessions.Add(carSession);
                var value = await _context.SaveChangesAsync();

                if (value == 0) {
                    throw new Exception("Errors in inserting the shopping cart");
                }

                int id = carSession.Id;

                foreach (var item in request.ProductsList!) {
                    var detailSession = new CarSessionDetail
                    {
                        DateCreated = DateTime.Now,
                        CarSessionId = id,
                        ProductSelected = item.ProductId,
                        PriceProduct = item.PriceProduct,
                        Quantity = item.Quantity
                    };

                    _context.CarSessionDetails.Add(detailSession);
                }

                value = await _context.SaveChangesAsync();

                if (value > 0) {
                    return Unit.Value;
                }

                throw new Exception("Could not insert shopping cart detail");

            }

            private double GetPriceTotal(List<CarDetailDto> items)
            {
              double total = 0.00;

              foreach (var item in items)
              {
                total += (item.PriceProduct * item.Quantity);
              }

              return total;
            }
        }     
    }
}