using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class ProductTypeListViewModel
    {
        private ProductType x;

        public ProductTypeListViewModel(ProductType x)
        {
            this.x = x;
        }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
    }
}
