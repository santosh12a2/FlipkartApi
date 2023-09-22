using AutoMapper;
using FlipkartApi.DTOs;
using FlipkartApi.Entites;
using FlipkartApi.Filters;
using FlipkartApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlipkartApi.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;

        public IProductProvider provider { get; }

        public ProductsController(IMapper mapper, IProductProvider provider)
        {
            this.mapper = mapper;
            this.provider = provider;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return provider.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return provider.GetById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Product Post([FromBody] ProductDTO pdto)
        {
            return provider.Add(mapper.Map<Product>(pdto));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] ProductDTO pdto)
        {
            return provider.Update(mapper.Map<Product>(pdto));

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return provider.Delete(id);
        }

        //[HttpGet]
        //public IActionResult GetLogFile()
        //{
        //    string logFilePath = "E:\\RecentRepos\\FlipkartApi\\LogData\\LogFile.txt";
        //    if(System.IO.File.Exists(logFilePath))
        //    {
        //        string logContent=System.IO.File.ReadAllText(logFilePath);
        //        return Ok(logContent);
        //    }
        //    else
        //    {
        //        return NotFound("Data not found");
        //    }
        //}
    }
}
