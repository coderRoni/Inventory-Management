using Inventory.Models;
using Inventory.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class CreateShipmentTypeViewModel
    {
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
        public CreateShipmentTypeViewModel()
        {

        }
        public CreateShipmentTypeViewModel(ShipmentType model)
        {
            ShipmentTypeName = model.ShipmentTypeName;
            Description = model.Description;
        }
        public ShipmentType Convert(CreateShipmentTypeViewModel vm)
        {
            ShipmentType model = new ShipmentType();
            model.ShipmentTypeName = vm.ShipmentTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
