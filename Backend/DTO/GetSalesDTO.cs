using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class GetSalesDTO
    {
        public int StoreId { get; set; }
        public string OrderStatus { get; set; }
        public int InvoiceStatus { get; set; }
    }
}

