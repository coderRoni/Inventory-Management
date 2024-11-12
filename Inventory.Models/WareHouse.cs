using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class WareHouse
    {
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public string Description { get; set; }
        [Display(Name ="Branch")]
        public int BranchId { get; set; }
    }
}
