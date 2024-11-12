using Inventory.Repository.Paging;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.SalesTypeService
{
    public interface ISalesTypeService
    {
        Task<PaginatedList<SaleTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateSalesTypeViewModel model);
        void Update(SalesTypeViewModel model);
        void Delete(int id);
        SalesTypeViewModel GetById(int id);
    }
}
