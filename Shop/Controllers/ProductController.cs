using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Shop
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IWebHostEnvironment _environment;


        public ProductController(IProductServices productService, IWebHostEnvironment environment)
        {
            _productServices = productService;
            _environment = environment;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<Product> products = new();

            try
            {
                products = _productServices.GetProducts();

                // After deleting, show message
                if (TempData.TryGetValue("DeleteConfirmation", out var deleteConfirmationMessage))
                {
                    ViewBag.DeleteConfirmation = deleteConfirmationMessage.ToString();
                }
                else
                {
                    ViewBag.DeleteConfirmation = null; // No message available
                }
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(e);
            }

            return View(products);
        }

        // GET: ProductController
        public ActionResult Admin()
        {
            List<Product> products = new();

            try
            {
                products = _productServices.GetProducts();

                // After deleting, show message
                if (TempData.TryGetValue("DeleteConfirmation", out var deleteConfirmationMessage))
                {
                    ViewBag.DeleteConfirmation = deleteConfirmationMessage.ToString();
                }
                else
                {
                    ViewBag.DeleteConfirmation = null; // No message available
                }
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(e);
            }

            return View("Index",products);
        }

        // GET: ProductController
        public ActionResult Home()
        {
            List<Product> products = new();

            try
            {
                products = _productServices.GetProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View("Index",products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product product = new();

            try
            {
                product = _productServices.GetProductById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        private bool ValidateImageFile(IFormFile imageFile, out byte[] imageData)
        {
            imageData = null;

            if (imageFile == null || imageFile.Length == 0)
            {
                ViewBag.Message = "Please upload an image file.";
                return false;
            }

            // Check file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                ViewBag.Message = "Invalid file type. Only JPG, JPEG, PNG, and GIF files are allowed.";
                return false;
            }

            // Check content type
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedContentTypes.Contains(imageFile.ContentType.ToLowerInvariant()))
            {
                ViewBag.Message = "Invalid content type. Only JPG, JPEG, PNG, and GIF files are allowed.";
                return false;
            }

            // Convert the image file to byte array
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                imageData = memoryStream.ToArray();
            }

            return true;
        }

        // POST: ProductController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile imageFile)
        {
            try
            {
                if (ValidateImageFile(imageFile, out var imageData))
                {
                    product.ImageData = imageData;
                    _productServices.CreateProduct(product);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Message = "Invalid image file. Please upload a valid JPG, JPEG, PNG, or GIF file.";
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error creating product: {ex.Message}";
                return View(product);
            }
        }


        // GET: ProductController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Product productToEdit = _productServices.GetProductById(id);
            return View(productToEdit);
        }

        // POST: ProductController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product, IFormFile imageFile)
        {
            try
            {
                // Check if a new image is provided
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Validate and update the image
                    if (ValidateImageFile(imageFile, out var imageData))
                    {
                        product.ImageData = imageData;
                    }
                    else
                    {
                        ViewBag.Message = "Invalid image file. Please upload a valid JPG, JPEG, PNG, or GIF file.";
                        return View(product);
                    }
                }

                _productServices.EditProduct(id, product);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error editing product: {ex.Message}";
                return View(product);
            }
        }
    }
}
