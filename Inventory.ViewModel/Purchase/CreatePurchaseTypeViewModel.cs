using Inventory.Models;
using Inventory.ViewModel.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Purchase
{
    public class CreatePurchaseTypeViewModel
    {
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
        public CreatePurchaseTypeViewModel()
        {
                
        }
        public PurchaseType Convert(CreatePurchaseTypeViewModel model)
        {
            return new PurchaseType
            {
                PurchaseTypeName = model.PurchaseTypeName,
                Description = model.Description,
            };
        }
    }
}
