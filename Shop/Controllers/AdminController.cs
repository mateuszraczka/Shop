using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop
{
    public class AdminController : Controller
    {
        private readonly IProductServices _productService;

        public AdminController(IProductServices productServices)
        {
            _productService = productServices;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            List<Product> products = new();

            try
            {
                products = _productService.GetProducts();
                string deleteConfirmationMessage;

                //After deleting show message
                if (TempData.ContainsKey("DeleteConfirmation"))
                {
                    deleteConfirmationMessage = TempData["DeleteConfirmation"] as string;
                }

                else
                {
                    throw new Exception("There was no 'DeleteConfirmation' key found in TempData");
                }

                ViewBag.DeleteConfirmation = deleteConfirmationMessage;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
           

            return View(products);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
