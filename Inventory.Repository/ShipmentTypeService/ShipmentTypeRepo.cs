using Inventory.Repository.Paging;
using Inventory.ViewModel.Shipment;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ShipmentTypeService
{
    public class ShipmentTypeRepo : IShipmentTypeRepo
    {
        private ApplicationDbContext _context;

        public ShipmentTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateShipmentTypeViewModel vm)
        {
            var model = new CreateShipmentTypeViewModel().Convert(vm);
            _context.ShipmentTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.ShipmentTypes.Where(x => x.ShipmentTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.ShipmentTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public async Task<PaginatedList<ShipmentTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var shipmentTypes = _context.ShipmentTypes.AsQueryable(); // Keep this as IQueryable for EF querying

            // Get the total count for pagination
            var count = await shipmentTypes.CountAsync();

            // Apply pagination and fetch the data
            var items = await shipmentTypes.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            // Now apply the transformation to the view model after fetching from the database
            var vm = items.ModelToVM().ToList();

            // Return a paginated list using the transformed view models
            return new PaginatedList<ShipmentTypeListViewModel>(vm, count, pageNumber, pageSize);
        }

        public ShipmentTypeViewModel GetById(int id)
        {
            var model = _context.ShipmentTypes.Find(id);
            var vm = new ShipmentTypeViewModel(model);
            return vm;
        }

        public void Update(ShipmentTypeViewModel vm)
        {
            var model = _context.ShipmentTypes.Where(x => x.ShipmentTypeId == vm.ShipmentTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.ShipmentTypeName = vm.ShipmentTypeName;
            }
            _context.SaveChanges();
        }
    }
}
