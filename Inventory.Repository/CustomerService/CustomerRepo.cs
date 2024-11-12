using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateCustomerViewModel vm)
        {
            var model = new CreateCustomerViewModel().Convert(vm);
            _context.Customers.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Customers.Find(id);
            if (model != null)
            {
                _context.Customers.Remove(model);
                _context.SaveChanges();
            }
        }

        public async Task<PaginatedList<CustomerViewModel>> GetAll(int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var customerList = _context.Customers.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await customerList.CountAsync();

            // Apply pagination and fetch the data
            var items = await customerList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<CustomerViewModel>(vm, count, pageNumber, pageSize);
        }

        public CustomerViewModel GetById(int id)
        {
            var model = _context.Customers.Find(id);
            var vm = new CustomerViewModel(model);
            return vm;
        }

        public void Update(CustomerViewModel vm)
        {
            var model = _context.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefault();
            if (model != null)
            {
                model.CustomerName = vm.CustomerName;
                model.Address = vm.Address;
                model.CustomerTypeId = vm.CustomerTypeId;
                model.City = vm.City;
                model.State = vm.State;
                model.ZipCode = vm.ZipCode;
                model.Phone = vm.Phone;
                model.Email = vm.Email;
                model.ContactPerson = vm.ContactPerson;
            }
            _context.SaveChanges();
        }
    }
}
