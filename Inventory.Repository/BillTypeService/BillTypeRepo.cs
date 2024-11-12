using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        //public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        //{
        //    var billTypes = _context.BillTypes;
        //    var vm = billTypes.ModelToVM().AsQueryable();
        //    return await PaginatedList<BillTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        //}
        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var billTypes = _context.BillTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await billTypes.CountAsync();

            // Apply pagination and fetch the data
            var items = await billTypes.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<BillTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public void Add(CreateBillTypeViewModel model)
        {
            var billType = model.VMToModel();
            _context.BillTypes.Add(billType);
            _context.SaveChanges();
        }

        public void Update(BillTypeViewModel vm)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == vm.BillTypeId).FirstOrDefault();
            if (model != null)
            {
                model.BillTypeName = vm.BillTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            if (model != null)
            {
              _context.BillTypes.Remove(model);  
            }
            _context.SaveChanges();
        }

        public BillTypeViewModel GetById(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            var vm = new BillTypeViewModel(model);
            return vm;
        }
    }
}
