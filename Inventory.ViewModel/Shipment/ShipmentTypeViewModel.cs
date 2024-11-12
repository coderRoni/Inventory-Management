using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class ShipmentTypeViewModel
    {
        public int ShipmentTypeId { get; set; }
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
        public ShipmentTypeViewModel()
        {

        }
        public ShipmentTypeViewModel(ShipmentType model)
        {
            ShipmentTypeId = model.ShipmentTypeId;
            ShipmentTypeName = model.ShipmentTypeName;
            Description = model.Description;
        }
        public ShipmentType Convert(ShipmentTypeViewModel vm)
        {
            ShipmentType model = new ShipmentType();
            model.ShipmentTypeId = vm.ShipmentTypeId;
            model.ShipmentTypeName = vm.ShipmentTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
