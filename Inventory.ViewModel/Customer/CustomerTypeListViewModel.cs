using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Customer
{
    public class CustomerTypeListViewModel
    {
        private CustomerType x;

        public CustomerTypeListViewModel(CustomerType x)
        {
            this.x = x;
        }

        public int CustomerTypeId { get; set; }
        [Required]
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }
    }
}
