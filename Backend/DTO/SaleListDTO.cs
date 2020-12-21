using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class SaleListDTO
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string TaxNumber { get; set; }
        public string City { get; set; }
        public string CompanyTitle { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public string CargoCompany { get; set; }
        public string CargoPayment { get; set; }
        public DateTime CargoDate { get; set; }
    }
}
