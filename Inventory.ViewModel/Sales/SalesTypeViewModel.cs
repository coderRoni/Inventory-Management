using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Sales
{
    public class SalesTypeViewModel
    {
        public int SalesTypeId { get; set; }
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
        public SalesTypeViewModel()
        {

        }
        public SalesTypeViewModel(SalesType model)
        {
            SalesTypeId = model.SalesTypeId;
            SalesTypeName = model.SalesTypeName;
            Description = model.Description;
        }
        public SalesType Convert (SalesTypeViewModel vm)
        {
            SalesType model = new SalesType();
            model.SalesTypeId = vm.SalesTypeId;
            model.SalesTypeName = vm.SalesTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
