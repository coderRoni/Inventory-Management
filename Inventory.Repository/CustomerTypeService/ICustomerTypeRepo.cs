﻿using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerTypeService
{
    public interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateCustomerTypeViewModel model);
        void Update(CustomerTypeViewModel model);
        void Delete(int id);
        CustomerTypeViewModel GetById(int id);
        IEnumerable<CustomerTypeListViewModel> GetALLwithOutPagging();
        Task<PaginatedList<CustomerTypeListViewModel>> Search(string searching, int pageSize, int pageNumber);
    }
}
