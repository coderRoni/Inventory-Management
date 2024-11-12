using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Sales
{
    public class SaleTypeListViewModel
    {
        private SalesType x;

        public SaleTypeListViewModel(SalesType x)
        {
            this.x = x;
        }
        public int SalesTypeId { get; set; }
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
    }
}
