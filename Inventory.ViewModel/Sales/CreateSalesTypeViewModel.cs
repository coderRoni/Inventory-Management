using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Sales
{
    public class CreateSalesTypeViewModel
    {
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
        public CreateSalesTypeViewModel()
        {
                
        }
        public CreateSalesTypeViewModel(SalesType model)
        {
            SalesTypeName = model.SalesTypeName;
            Description = model.Description;
        }
        public SalesType Convert(CreateSalesTypeViewModel vm)
        {
            SalesType model = new SalesType();
            model.SalesTypeName = vm.SalesTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
