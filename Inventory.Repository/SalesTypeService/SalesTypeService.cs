using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.SalesTypeService
{
    public class SalesTypeService : ISalesTypeService
    {
        private ApplicationDbContext _context;

        public SalesTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateSalesTypeViewModel vm)
        {
            var model = new CreateSalesTypeViewModel().Convert(vm);
            _context.SalesTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.SalesTypes.Where(x => x.SalesTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.SalesTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<SaleTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var salesTypes = _context.SalesTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await salesTypes.CountAsync();

            // Apply pagination and fetch the data
            var items = await salesTypes.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<SaleTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public SalesTypeViewModel GetById(int id)
        {
            var model = _context.SalesTypes.Find(id);
            var vm = new SalesTypeViewModel(model);
            return vm;
        }

        public void Update(SalesTypeViewModel vm)
        {
            var model = _context.SalesTypes.Where(x => x.SalesTypeId == vm.SalesTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.SalesTypeName = vm.SalesTypeName;
            }
            _context.SaveChanges();
        }
    }
}
