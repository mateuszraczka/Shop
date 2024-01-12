using Shop.Models;

namespace Shop
{
    public interface IProductFetchService
    {
        List<Product> GetProducts();
        List<Product> GetProductsFilteredByName(string productName);
        Product GetProductById(int id);
    }
}
