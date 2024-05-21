using MediatR;
using Microsoft.EntityFrameworkCore;
using ECommerce.Api.OrderManagement.Persistence;

namespace ECommerce.Api.OrderManagement.Aplication
{
    public class Query
    {
        public class Execute : IRequest<CarDto> {
            public int CarSessionId { get; set; }
        }

        public class Manager : IRequestHandler<Execute, CarDto>
        {
            private readonly CarContext _context;

            public Manager(CarContext context) {
                _context = context;
            }

            public async  Task<CarDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var carSession = await _context.CarSessions.FirstOrDefaultAsync(x => x.Id == request.CarSessionId);
                var carSessionDetail = await _context.CarSessionDetails.Where(x => x.CarSessionId == request.CarSessionId).ToListAsync();

                var listCarsDto = new  List<CarDetailDto>();

                foreach (var item in carSessionDetail) {

                        var carDetail = new CarDetailDto
                        {
                            ProductId = item.ProductSelected,
                            Quantity = item.Quantity,
                            PriceProduct = item.PriceProduct                  
                        };
                        listCarsDto.Add(carDetail);
                    
                }

                 var carritoSesionDto = new CarDto();

                if (carSession != null)
                {
                  carritoSesionDto = new CarDto
                  {
                    Id = carSession.Id,
                    DateRegister = carSession.DateRegister,
                    ListDetails = listCarsDto,
                    Total = carSession.Total
                  };
                }

                return carritoSesionDto;
            }
        }

    }
}
