using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Models.Contexts;

namespace Shop
{
    public class ProductFetchService : IProductFetchService
    {
        private readonly ProductsDbContext _context;

        public ProductFetchService(ProductsDbContext context) 
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                products = _context.Products.ToList();

                if(products == null)
                {
                    throw new ArgumentNullException("Products fetch - null error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = new();
            try
            {
                product = _context.Find<Product>(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
        }

        public List<Product> GetProductsFilteredByName(string name)
        {
            List<Product> products = new();
            try
            {
                products = _context.Products
                 .Where(p => EF.Functions.Like(p.Name, $"%{name.ToLower()}%"))
                 .ToList();

                if (products == null)
                {
                    throw new ArgumentNullException("Products fetch - null error");
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }
    }
}
