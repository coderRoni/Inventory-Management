using Inventory.Repository.Paging;
using Inventory.ViewModel.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ShipmentTypeService
{
    public interface IShipmentTypeRepo
    {
        Task<PaginatedList<ShipmentTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateShipmentTypeViewModel model);
        void Update(ShipmentTypeViewModel model);
        void Delete(int id);
        ShipmentTypeViewModel GetById(int id);
    }
}
