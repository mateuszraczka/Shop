using Shop.Models;

namespace Shop
{
    public class ProductEditService : IProductEditService
    {
        private readonly IProductFetchService _productGetService;

        public ProductEditService(IProductFetchService productGetService)
        {
            _productGetService = productGetService;
        }

        public bool EditProduct(int productId, Product editedProduct)
        {
            try
            {
                if (editedProduct == null)
                {
                    throw new Exception("Invalid edited product.");
                }

                Product product = _productGetService.GetProductById(productId);

                product.StockQuantity = editedProduct.StockQuantity;
                product.Price = editedProduct.Price;
                product.Name = editedProduct.Name;
                product.Description = editedProduct.Description;
                product.ImageUrl = editedProduct.ImageUrl;
                product.CategoryId = editedProduct.CategoryId;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EditProduct failed: {ex.Message}");
                return false;
            }
        }
    }
}
