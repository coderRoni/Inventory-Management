using Inventory.Repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PaymentTypes
{
    public interface IPaymentTypeRepo
    {
        Task<PaginatedList<PaymentTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreatePaymentTypeViewModel model);
        void Update(PaymentTypeViewModel model);
        void Delete(int id);
        PaymentTypeViewModel GetById(int id);
    }
}
