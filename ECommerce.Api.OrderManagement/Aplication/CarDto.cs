using System;
using System.Collections.Generic;

namespace ECommerce.Api.OrderManagement.Aplication
{
    public class CarDto
    {
        public int Id { get; set; }

        public DateTime? DateRegister { get; set; }

        public List<CarDetailDto>? ListDetails { get; set; }

        public double Total { get; set; }
    }
}
