using AspNetTest_3.Data;
using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetTest_3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IRepository<ProductType> _productTypeRepository;

        public ProductTypeController(IRepository<ProductType> repository)
        {
            _productTypeRepository = repository;
        }

        // GET: api/<ProductTypeController>
        [HttpGet]
        public IEnumerable<ProductType> Get()
        {
            return _productTypeRepository.GetAll();
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        public ProductType Get(int id)
        {
            return _productTypeRepository.GetById(id);
        
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Post([FromBody] ProductType value)
        {
            _productTypeRepository.Create(value);
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Put(int id, [FromBody] ProductType value)
        {
            _productTypeRepository.Update(value);
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Delete(int id)
        {
            _productTypeRepository.Delete(id);
        }
    }
}
