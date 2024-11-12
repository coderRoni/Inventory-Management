using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Vendor
{
    public class VendorTypeListViewModel
    {
        private VendorType x;

        public VendorTypeListViewModel(VendorType x)
        {
            this.x = x;
        }

        public int VendorTypeId { get; set; }
        public string VendorTypeName { get; set; }
        public string Description { get; set; }
    }
}
