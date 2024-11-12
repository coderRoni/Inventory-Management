using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class ShipmentTypeListViewModel
    {
        private ShipmentType x;
        public ShipmentTypeListViewModel(ShipmentType x)
        {
            this.x = x;
        }
        public int ShipmentTypeId { get; set; }
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
    }
}
