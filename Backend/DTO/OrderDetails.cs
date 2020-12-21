using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class OrderDetails
    {      
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductCode2 { get; set; }       
        public double Price { get; set; }     
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string CargoCompany { get; set; }
        public string CargoLabelCode { get; set; }
        public string CargoPayment { get; set; }
        public DateTime CargoDate { get; set; }      
    }
}
