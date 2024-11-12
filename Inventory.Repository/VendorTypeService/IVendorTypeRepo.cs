using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.VendorTypeService
{
    public interface IVendorTypeRepo
    {
        Task<PaginatedList<VendorTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateVendorTypeViewModel model);
        void Update(VendorTypeViewModel model);
        void Delete(int id);
        VendorTypeViewModel GetById(int id);
    }
}
