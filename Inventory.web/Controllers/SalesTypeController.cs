using Inventory.Repository.BillTypeService;
using Inventory.Repository.SalesTypeService;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Sales;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class SalesTypeController : Controller
    {
        private ISalesTypeService _salesTypeService;

        public SalesTypeController(ISalesTypeService salesTypeService)
        {
            _salesTypeService = salesTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var saleType = await _salesTypeService.GetAll(pageSize, pageNumber);
            return View(saleType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSalesTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _salesTypeService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _salesTypeService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(SalesTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _salesTypeService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _salesTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
