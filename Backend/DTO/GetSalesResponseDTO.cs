using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class GetSalesResponseDTO
    {
        public int TotalOrderCount { get; set; }
        public int TotalNotInvoicedCount { get; set; }
        public int TotalUnreadCount { get; set; }
        public Orders[] Orders { get; set; }

    }
}
