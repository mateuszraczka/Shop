namespace Shop.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
