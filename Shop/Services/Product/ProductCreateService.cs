using Shop.Models;

namespace Shop
{
    public class ProductCreateService : IProductCreateService
    {
        public bool CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException("product", "The product provided is null.");
                }

                ProductFetchService.products.Add(product); // Add the product to the static collection. It will be changed once database will be added.
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return false;
        }
    }
}
