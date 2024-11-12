using Inventory.Repository.BillTypeService;
using Inventory.Repository.InvoiseServices;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class InvoiceTypesController : Controller
    {
        private IInvoiceTypeRepo _invoiceTypeRepo;
        public InvoiceTypesController(IInvoiceTypeRepo invoiceTypeRepo)
        {
            _invoiceTypeRepo = invoiceTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var invoiceType = await _invoiceTypeRepo.GetAll(pageSize, pageNumber);
            return View(invoiceType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateInvoiceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _invoiceTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(InvoiceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _invoiceTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
