using Shop.Models;
using Shop.Models.Contexts;

namespace Shop
{
    public class ProductCreateService : IProductCreateService
    {
        private readonly ProductsDbContext _context;

        public ProductCreateService(ProductsDbContext context) 
        { 
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException("The product provided is null.");
                }

                using (_context)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }
    }
}
