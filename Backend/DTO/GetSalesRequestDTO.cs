using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class GetSalesRequestDTO
    {
        public string ApiCode { get; set; }
        public int StoreId { get; set; }
        public string OrderStatus { get; set; }
        public int InvoiceStatus { get; set; } 
    }
}
