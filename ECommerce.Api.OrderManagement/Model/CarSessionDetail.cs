using System;

namespace ECommerce.Api.OrderManagement.Model
{
    public class CarSessionDetail
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public string ProductSelected { get; set; }

        public double PriceProduct { get; set; }

        public int Quantity { get; set; }

        public int CarSessionId { get; set; }

    }
}
