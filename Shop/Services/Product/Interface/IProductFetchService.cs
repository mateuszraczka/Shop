using Shop.Models;

namespace Shop
{
    public interface IProductFetchService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}
