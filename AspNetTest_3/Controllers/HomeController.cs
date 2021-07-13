using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using AspNetTest_3.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspNetTest_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _productTypeReposirory;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepository<Product> productsRepository,
            IRepository<ProductType> productTypeReposirory,
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            _productRepository = productsRepository;
            _productTypeReposirory = productTypeReposirory;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Products")]
        public IActionResult Products()
        {
            HomeMainViewModel homeMainViewModel = new HomeMainViewModel();
            homeMainViewModel.Products = _productRepository.GetAll();
            homeMainViewModel.ProductTypes = _productTypeReposirory.GetAll();
            homeMainViewModel.User = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(homeMainViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
