using Inventory.Repository.SalesTypeService;
using Inventory.Repository.ShipmentTypeService;
using Inventory.ViewModel.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class ShipmentTypesController : Controller
    {
        private IShipmentTypeRepo _shipmentType;
        public ShipmentTypesController(IShipmentTypeRepo shipmentType)
        {
            _shipmentType = shipmentType;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var shipment = await _shipmentType.GetAll(pageSize, pageNumber);
            return View(shipment);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateShipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentType.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _shipmentType.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ShipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentType.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _shipmentType.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
