using AspNetTest_3.Data;
using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetTest_3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> repository)
        {
            _productRepository = repository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Post([FromBody] Product value)
        {
            _productRepository.Create(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Put(int id, [FromBody] Product value)
        {
            _productRepository.Update(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Administrator)]
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
