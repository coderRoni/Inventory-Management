using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.InvoiseServices
{
    public class InvoiceTypeRepo : IInvoiceTypeRepo
    {
        private ApplicationDbContext _context;

        public InvoiceTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateInvoiceTypeViewModel vm)
        {
            var model = new CreateInvoiceTypeViewModel().Convert(vm);
            _context.InvoiceTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.InvoiceTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var invoiveTypeList = _context.InvoiceTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await invoiveTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await invoiveTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<InvoiceTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public InvoiceTypeViewModel GetById(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            var vm = new InvoiceTypeViewModel(model);
            return vm;
        }

        public void Update(InvoiceTypeViewModel vm)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == vm.InvoiceTypeId).FirstOrDefault();
            if (model != null)
            {
                model.InvoiceTypeName = vm.InvoiceTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
