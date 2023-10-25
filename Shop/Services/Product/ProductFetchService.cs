using Shop.Models;

namespace Shop
{
    public class ProductFetchService : IProductFetchService
    {
        //Sample data for testing
        //For testing purposes it is public - remember to change it to private and remove static later when adding database
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, Name = "HP 17 CN2063CL", Description = "Description 1", Price = 3499.00m, ImageUrl = "/Images/HP-17-CN2063CL.jpg" },
            new Product { ProductId = 2, Name = "HP OMEN 16 K0750NW", Description = "Description 2", Price = 5771.60m, ImageUrl = "/Images/HP-OMEN-16-K0750NW.jpg" },
            new Product { ProductId = 3, Name = "Huawei Matebook D15", Description = "Description 2", Price = 2844.80m, ImageUrl = "/Images/Huawei-Matebook-D15.jpg" },
        };

        public List<Product> GetProducts()
        {
            // Later it will fetch from database
            return products.ToList();
        }

        public Product GetProductById(int productId)
        {
            try
            {
                Product product = products.FirstOrDefault(p => p.ProductId == productId);

                if (product is null)
                {
                    if (products.Count > 0)
                    {
                        throw new Exception($"Product with ID {productId} was not found in the products list.");
                    }
                    else
                    {
                        throw new Exception($"Product with ID {productId} does not exist because there are no products in the products list.");
                    }
                }

                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

    }
}
