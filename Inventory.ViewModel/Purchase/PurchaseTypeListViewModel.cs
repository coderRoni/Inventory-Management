using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Purchase
{
    public class PurchaseTypeListViewModel
    {
        private PurchaseType x;

        public PurchaseTypeListViewModel(PurchaseType x)
        {
            this.x = x;
        }
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
    }
}
