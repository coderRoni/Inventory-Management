using Inventory.Repository.Paging;
using Inventory.ViewModel.Payment;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PurchaseTypeService
{
    public interface IPurchaseTypeRepo
    {
        Task<PaginatedList<PurchaseTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreatePurchaseTypeViewModel model);
        void Update(PurchaseTypeViewModel model);
        void Delete(int id);
        PurchaseTypeViewModel GetById(int id);
    }
}
