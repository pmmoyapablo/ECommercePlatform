using System;
using System.Collections.Generic;

namespace ECommerce.Api.OrderManagement.Model
{
    public class CarSession
    {
        public int Id { get; set; }

        public DateTime? DateRegister { get; set; }

        public double Total { get; set; }
    }
}
