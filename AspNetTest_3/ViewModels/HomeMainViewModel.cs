using AspNetTest_3.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AspNetTest_3.ViewModels
{
    public class HomeMainViewModel
    {
        public IdentityUser User { get; set; }

        public IEnumerable<ProductType> ProductTypes { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
