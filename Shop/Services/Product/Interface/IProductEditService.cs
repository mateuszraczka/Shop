using Shop.Models;

namespace Shop
{
    public interface IProductEditService
    {
        bool EditProduct(int productId, Product updatedProduct);
    }
}