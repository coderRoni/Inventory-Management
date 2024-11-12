using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Invoice
{
    public class InvoiceTypeListViewModel
    {
        private InvoiceType x;

        public InvoiceTypeListViewModel(InvoiceType x)
        {
            this.x = x;
        }

        public int InvoiceTypeId { get; set; }
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
