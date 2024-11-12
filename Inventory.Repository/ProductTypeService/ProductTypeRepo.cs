using Inventory.Repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateProductTypeViewModel vm)
        {
            var model = new CreateProductTypeViewModel().Convert(vm);
            _context.ProductTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.ProductTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productTypeList = _context.ProductTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await productTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await productTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<ProductTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public ProductTypeViewModel GetById(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            var vm = new ProductTypeViewModel(model);
            return vm;
        }

        public void Update(ProductTypeViewModel vm)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == vm.ProductTypeId).FirstOrDefault();
            if (model != null)
            {
                model.ProductTypeName = vm.ProductTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
