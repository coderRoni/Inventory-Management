using Inventory.Repository.CustomerService;
using Inventory.Repository.CustomerTypeService;
using Inventory.ViewModel.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo _customerRepo;
        private ICustomerTypeRepo _customerTypeRepo;

        public CustomerController(ICustomerRepo customerRepo, ICustomerTypeRepo customerTypeRepo)
        {
            _customerRepo = customerRepo;
            _customerTypeRepo = customerTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var custromer = await _customerRepo.GetAll(pageSize, pageNumber);
            return View(custromer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.customerTypes = new SelectList(_customerTypeRepo.GetALLwithOutPagging(), "CustomerTypeId", "CustomerTypeName");
            return View();  

        }
        [HttpPost]
        public IActionResult Create(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerRepo.GetById(id);
            ViewBag.customerTypes = new SelectList(_customerTypeRepo.GetALLwithOutPagging(), "CustomerTypeId", "CustomerTypeName",model.CustomerTypeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _customerRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
