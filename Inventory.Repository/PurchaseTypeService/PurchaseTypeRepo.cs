using Inventory.Repository.Paging;
using Inventory.ViewModel.Payment;
using Inventory.ViewModel.Purchase;
using Microsoft.EntityFrameworkCore;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PurchaseTypeService
{
    public class PurchaseTypeRepo : IPurchaseTypeRepo
    {
        private ApplicationDbContext _context;

        public PurchaseTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreatePurchaseTypeViewModel vm)
        {
            var model = new CreatePurchaseTypeViewModel().Convert(vm);
            _context.PurchaseTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.PurchaseTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<PurchaseTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var purchaseTypeList = _context.PurchaseTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await purchaseTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await purchaseTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<PurchaseTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public PurchaseTypeViewModel GetById(int id)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == id).FirstOrDefault();
            var vm = new PurchaseTypeViewModel(model);
            return vm;
        }

        public void Update(PurchaseTypeViewModel vm)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == vm.PurchaseTypeId).FirstOrDefault();
            if (model != null)
            {
                model.PurchaseTypeName = vm.PurchaseTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
