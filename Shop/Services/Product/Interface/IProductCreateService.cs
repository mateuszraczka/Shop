using Shop.Models;

namespace Shop
{
    public interface IProductCreateService
    {
        bool CreateProduct(Product product);
    }
}
