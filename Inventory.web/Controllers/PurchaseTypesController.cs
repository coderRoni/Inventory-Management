using Inventory.Repository.PaymentTypes;
using Inventory.Repository.PurchaseTypeService;
using Inventory.ViewModel.Payment;
using Inventory.ViewModel.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class PurchaseTypesController : Controller
    {
        private IPurchaseTypeRepo _purchaseTypeRepo;
        public PurchaseTypesController(IPurchaseTypeRepo purchaseTypeRepo)
        {
            _purchaseTypeRepo = purchaseTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var purchaseType = await _purchaseTypeRepo.GetAll(pageSize, pageNumber);
            return View(purchaseType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePurchaseTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _purchaseTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _purchaseTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _purchaseTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _purchaseTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
