using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Payment
{
    public class PaymentTypeListViewModel
    {
        private PaymentType x;

        public PaymentTypeListViewModel(PaymentType x)
        {
            this.x = x;
        }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
    }
}
