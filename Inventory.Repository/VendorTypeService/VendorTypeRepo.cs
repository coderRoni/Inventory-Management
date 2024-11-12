using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Vendor;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.VendorTypeService
{
    public class VendorTypeRepo : IVendorTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public VendorTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateVendorTypeViewModel vm)
        {
            var model = new CreateVendorTypeViewModel().Convert(vm);
            _context.VendorTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.VendorTypes.Find(id);
            if (model != null)
            {
                _context.VendorTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        public async Task<PaginatedList<VendorTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var vendorTypes = _context.VendorTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await vendorTypes.CountAsync();

            // Apply pagination and fetch the data
            var items = await vendorTypes.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<VendorTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public VendorTypeViewModel GetById(int id)
        {
            var model = _context.VendorTypes.Find(id);
            var vm = new VendorTypeViewModel(model);
            return vm;
        }

        public void Update(VendorTypeViewModel vm)
        {
            var model = _context.VendorTypes.Where(x => x.VendorTypeId == vm.VendorTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.VendorTypeName = vm.VendorTypeName;
            }
            _context.SaveChanges();
        }
    }
}
