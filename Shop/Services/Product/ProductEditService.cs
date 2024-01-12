using Shop.Models;
using Shop.Models.Contexts;

namespace Shop
{
    public class ProductEditService : IProductEditService
    {
        private readonly IProductFetchService _productFetchService;
        private readonly ProductsDbContext _context;


        public ProductEditService(IProductFetchService productFetchService, ProductsDbContext context)
        {
            _productFetchService = productFetchService;
            _context = context;
        }

        public bool EditProduct(int productId, Product editedProduct)
        {
            try
            {
                if (editedProduct == null)
                {
                    throw new Exception("Invalid edited product.");
                }

                Product product = _productFetchService.GetProductById(productId);

                product.StockQuantity = editedProduct.StockQuantity;
                product.Price = editedProduct.Price;
                product.Name = editedProduct.Name;
                product.Description = editedProduct.Description;
                product.ImageData = editedProduct.ImageData;
                product.ImageFile = editedProduct.ImageFile;
                product.CategoryId = editedProduct.CategoryId;
                
                using (_context)
                {
                    _context.Update(product);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Edit Product failed: {ex.Message}");
            }

            return false;
        }
    }
}
