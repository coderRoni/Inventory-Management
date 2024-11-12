using Inventory.Repository.InvoiseServices;
using Inventory.Repository.PaymentTypes;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Payment;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.web.Controllers
{
    public class PaymentTypesController : Controller
    {
        private IPaymentTypeRepo _paymentTypeRepo;
        public PaymentTypesController(IPaymentTypeRepo paymentTypeRepo)
        {
            _paymentTypeRepo = paymentTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var paymentType = await _paymentTypeRepo.GetAll(pageSize, pageNumber);
            return View(paymentType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePaymentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _paymentTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PaymentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _paymentTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
