using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Vendor
{
    public class CreateVendorTypeViewModel
    {
        public string VendorTypeName { get; set; }
        public string Description { get; set; }
        public CreateVendorTypeViewModel()
        {
            
        }
        public VendorType Convert(CreateVendorTypeViewModel model)
        {
            return new VendorType
            {
                VendorTypeName = model.VendorTypeName,
                Description = model.Description
            };
        }
    }
}
