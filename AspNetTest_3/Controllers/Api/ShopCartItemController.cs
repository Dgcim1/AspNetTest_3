using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetTest_3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartItemController : ControllerBase
    {
        private readonly ILogger<ShopCartItemController> _logger;
        private readonly IRepository<ShopCartItem> _shopCartItemRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ShopCartItemController(
            ILogger<ShopCartItemController> logger,
            IRepository<ShopCartItem> shopCartItemRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _logger = logger;
            _shopCartItemRepository = shopCartItemRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/<ShopCartItemController>
        [HttpGet]
        public IEnumerable<ShopCartItem> Get()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                IdentityUser identityUser = _userManager.GetUserAsync(HttpContext.User).Result;
                return _shopCartItemRepository.GetAll().Where(x => x.UserId == identityUser.Id);
            }
            else
            {
                return null;//TODO unauthorized
            }
        }

        // POST api/<ShopCartItemController>
        [HttpPost]
        public void Post([FromBody] ShopCartItem value)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                IdentityUser identityUser = _userManager.GetUserAsync(HttpContext.User).Result;
                value.UserId = identityUser.Id;
                value.User = identityUser;
                _shopCartItemRepository.Create(value);
            }
            else
            {
                //TODO unauthorized
            }
        }

        // PUT api/<ShopCartItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ShopCartItem value)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                IdentityUser identityUser = _userManager.GetUserAsync(HttpContext.User).Result;
                ShopCartItem shopCartItem = _shopCartItemRepository.GetById(id);
                if(shopCartItem.UserId == value.UserId && identityUser.Id == value.UserId && shopCartItem.id == id)
                {
                    _shopCartItemRepository.Update(value);
                }
            }
            else
            {
                //TODO unauthorized
            }
        }

        // DELETE api/<ShopCartItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                IdentityUser identityUser = _userManager.GetUserAsync(HttpContext.User).Result;
                ShopCartItem shopCartItem = _shopCartItemRepository.GetById(id);
                if (identityUser.Id == shopCartItem.UserId && shopCartItem.id == id)
                {
                    _shopCartItemRepository.Delete(id);
                }
            }
            else
            {
                //TODO unauthorized
            }
        }
    }
}
