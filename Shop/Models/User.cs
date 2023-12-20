namespace Shop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
    }
}
