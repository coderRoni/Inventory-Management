using Inventory.Models;
using Inventory.ViewModel.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Payment
{
    public class CreatePaymentTypeViewModel
    {
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }

        public CreatePaymentTypeViewModel()
        {

        }
        public PaymentType Convert(CreatePaymentTypeViewModel model)
        {
            return new PaymentType
            {
                PaymentTypeName = model.PaymentTypeName,
                Description = model.Description,
            };
        }
    }
}
