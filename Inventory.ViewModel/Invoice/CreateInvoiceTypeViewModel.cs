using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Invoice
{
    public class CreateInvoiceTypeViewModel
    {
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
        public CreateInvoiceTypeViewModel()
        {
            
        }
        public InvoiceType Convert(CreateInvoiceTypeViewModel model)
        {
            return new InvoiceType
            {
                InvoiceTypeName = model.InvoiceTypeName,
                Description = model.Description,
            };
        }
    }
}
