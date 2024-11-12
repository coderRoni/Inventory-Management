using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ReceivedNote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTimeOffset GRNDate { get; set; }
        public string VendoreNumber { get; set; }
        public string VendorInvoiceNumber { get; set;}
        public int WareHouseId { get; set; }
        public bool IsFullReceive { get; set; } = true;
    }
}
