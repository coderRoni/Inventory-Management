using Inventory.Repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Payment;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PaymentTypes
{
    public class PaymentTypeRepo : IPaymentTypeRepo
    {
        private ApplicationDbContext _context;

        public PaymentTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreatePaymentTypeViewModel vm)
        {
            var model = new CreatePaymentTypeViewModel().Convert(vm);
            _context.PaymentTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.PaymentTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<PaymentTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var paymentTypeList = _context.PaymentTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await paymentTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await paymentTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<PaymentTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public PaymentTypeViewModel GetById(int id)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId == id).FirstOrDefault();
            var vm = new PaymentTypeViewModel(model);
            return vm;
        }

        public void Update(PaymentTypeViewModel vm)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId == vm.PaymentTypeId).FirstOrDefault();
            if (model != null)
            {
                model.PaymentTypeName = vm.PaymentTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
