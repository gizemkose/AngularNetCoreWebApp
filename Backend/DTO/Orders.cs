using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalIdentification { get; set; }
        public string Nickname { get; set; }
        public DateTime OrderDate { get; set; }
        public string IntegrationOrderCode { get; set; }
        public string OrderStatus { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string TaxAuthority { get; set; }
        public string TaxNumber { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string CompanyTitle { get; set; }
        public OrderDetails[] OrderDetails { get; set; }
    }
}
