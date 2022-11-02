
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContext = API_ServiceHavelsan.Context.DbContext;

namespace API_ServiceHavelsan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            using (DbContext context = new DbContext())
            {
                var result = context.Set<Product>().ToList();
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }


        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Product product)
        {
            using (DbContext context = new DbContext())
            {
                var addedEntity = context.Entry(product);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                if (addedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }

        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {

            using (DbContext context = new DbContext())
            {
                var entity = context.Set<Product>().FirstOrDefault(x => x.ProductId == id);
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                if (deletedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }


        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Product product)
        {
            using (DbContext context = new DbContext())
            {
                var updatedEntity = context.Entry(product);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                if (updatedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }

        }
        [HttpPost("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            using (DbContext context = new DbContext())
            {
                var result = context.Set<Product>().FirstOrDefault(x => x.ProductId == id);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }


        }
    }
}
