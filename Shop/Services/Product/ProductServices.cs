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

        public List<Product> GetProducts() =>
            _fetchService.GetProducts();

        public Product GetProductById(int productId) =>
            _fetchService.GetProductById(productId);

        public List<Product> GetProductsFilteredByName(string productName) =>
            _fetchService.GetProductsFilteredByName(productName);

        public bool DeleteProduct(int productId) => 
            _deleteService.DeleteProduct(productId);

        public bool EditProduct(int productId, Product updatedProduct) =>
            _editService.EditProduct(productId, updatedProduct);
      

        public bool CreateProduct(Product product) =>
            _createService.CreateProduct(product);
    }

}
