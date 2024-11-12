using Inventory.Models;
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

namespace Inventory.Repository.CustomerTypeService
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDbContext _context;

        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerTypeViewModel vm)
        {
            var model = new CreateCustomerTypeViewModel().Convert(vm);
            _context.CustomerTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.CustomerTypes.Find(id);
            if (model != null)
            {
                _context.CustomerTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        //public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        //{
        //    var customerTypeList = _context.CustomerTypes;
        //    var vm = customerTypeList.ModelToVM().AsQueryable();
        //    return await PaginatedList<CustomerTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        //}
        //-----------------------------
        //public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        //{
        //    int totalCount = 0;
        //    List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();
        //    try
        //    {
        //        int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
        //        var modelList = _context.CustomerTypes
        //            .Skip(ExcludeRecords).Take(pageSize).ToList();
        //        totalCount = _context.CustomerTypes.ToList().Count;
        //        vmList = ConvertModelToViewModelList(modelList);
        //    }
        //    catch (Exception) { throw; }
        //    var result = new PaginatedList<CustomerTypeListViewModel>
        //    {
        //        Data = vmList,
        //        TotalItem = totalCount,
        //        PageNunber = pageNumber,
        //        pageSize = pageSize
        //    };
        //    return result;
        //}

        public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var customerTypeList = _context.CustomerTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await customerTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await customerTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<CustomerTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public IEnumerable<CustomerTypeListViewModel> GetALLwithOutPagging()
        {
            var modelList = _context.CustomerTypes.ToList();
            var viewModelList = modelList.ModelToVM();
            return viewModelList;
        }

        public CustomerTypeViewModel GetById(int id)
        {
            var model = _context.CustomerTypes.Find(id);
            var vm = new CustomerTypeViewModel(model);
            return vm;
        }

        public async Task<PaginatedList<CustomerTypeListViewModel>> Search(string searching, int pageSize, int pageNumber)
        {
            // Fetch data from the database asynchronously
            var customerTypeList = _context.CustomerTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await customerTypeList.CountAsync();

            // Apply pagination and fetch the data
            var items = await customerTypeList.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<CustomerTypeListViewModel>(vm, count, pageNumber, pageSize);
        }


        public void Update(CustomerTypeViewModel vm)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == vm.CustomerTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.CustomerTypeName = vm.CustomerTypeName;
            }
            _context.SaveChanges();
        }
        private List<CustomerTypeListViewModel> ConvertModelToViewModelList(List<CustomerType> modelList)
        {
            return modelList.Select(x=> new CustomerTypeListViewModel(x)).ToList();
        }
    }
}
