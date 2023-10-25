using Shop.Models;

namespace Shop
{
    public class ProductDeleteService : IProductDeleteService
    {
        private readonly IProductFetchService _productFetchService;

        public ProductDeleteService(IProductFetchService productFetchService)
        {
            _productFetchService = productFetchService;
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                Product product = _productFetchService.GetProductById(productId);
                if (product != null)
                {
                    ProductFetchService.products.Remove(product); // It will be changed when database will be added
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                return false;
            }
        }
    }
}
