using Microsoft.AspNetCore.Identity;

namespace AspNetTest_3.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; } 
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
