using Shop.Models;

namespace Shop
{
    public class ProductServices : IProductServices
    {
        private readonly IProductFetchService _fetchService;
        private readonly IProductEditService _editService;
        private readonly IProductDeleteService _deleteService;
        private readonly IProductCreateService _createService;

        public ProductServices(
            IProductFetchService fetchService,
            IProductEditService editService,
            IProductDeleteService deleteService,
            IProductCreateService createService)
        {
            _fetchService = fetchService;
            _editService = editService;
            _deleteService = deleteService;
            _createService = createService;
        }

        public List<Product> GetProducts()
        {
            return _fetchService.GetProducts();
        }

        public Product GetProductById(int productId)
        {
            return _fetchService.GetProductById(productId);
        }

        public bool DeleteProduct(int productId)
        {
            return _deleteService.DeleteProduct(productId);
        }

        public bool EditProduct(int productId, Product updatedProduct)
        {
            return _editService.EditProduct(productId, updatedProduct);
        }

        public bool CreateProduct(Product product)
        {
            return _createService.CreateProduct(product);
        }
    }

}
