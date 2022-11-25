using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SmartElectronicsContext db;
        public ProductController(SmartElectronicsContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getProducts()
        {
            return Ok(await db.Products/*.Include(x => x.Category)*/.ToListAsync());
        }

        [HttpPost]

        public async Task<ActionResult> AddProduct(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                await db.SaveChangesAsync();
            }
            if(p == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetProdById{id}")]

        public async Task<ActionResult> GetProdById(int id)
        {
            Product p = await db.Products.FindAsync(id);
            return Ok(p);
        }

        [HttpPut]

        public async Task<ActionResult> EditProduct(int id,Product p)
        {
            db.Products.Update(p);
            await db.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete]

        public async Task<ActionResult> DeleteProduct(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            Product p = await db.Products.FindAsync(id);
            db.Products.Remove(p);
            db.SaveChanges();
            return Ok();
           
        }

    }
}
