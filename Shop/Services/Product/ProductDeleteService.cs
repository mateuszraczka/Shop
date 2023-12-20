using Shop.Models;
using Shop.Models.Contexts;

namespace Shop
{
    public class ProductDeleteService : IProductDeleteService
    {
        private readonly IProductFetchService _productFetchService;
        private readonly ProductsDbContext _context;

        public ProductDeleteService(IProductFetchService productFetchService, ProductsDbContext context)
        {
            _productFetchService = productFetchService;
            _context = context;
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                Product product = _productFetchService.GetProductById(productId);
                if (product == null)
                {
                    throw new Exception("Product Delete - Error, cannot find product to delete");
                }

                using (_context)
                {
                    _context.Remove(product);
                    _context.SaveChanges();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
            }

            return false;
        }
    }
}
