using Inventory.Repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductTypeService
{
    public interface IProductTypeRepo
    {
        Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateProductTypeViewModel model);
        void Update(ProductTypeViewModel model);
        void Delete(int id);
        ProductTypeViewModel GetById(int id);
    }
}
