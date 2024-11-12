using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.InvoiseServices
{
    public interface IInvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateInvoiceTypeViewModel model);
        void Update(InvoiceTypeViewModel model);
        void Delete(int id);
        InvoiceTypeViewModel GetById(int id);
    }
}
