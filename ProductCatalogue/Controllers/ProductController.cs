using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogue.Models;
using ProductCatalogue.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Globalization;

namespace ProductCatalogue.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context; 
        }

        // Create
        [HttpPost]
        public JsonResult Create(Product product)
        {
            var productInDb = _context.Products.Find(product.Id);

            if (productInDb == null)
            {
                _context.Products.Add(product);

                _context.SaveChanges();

                return new JsonResult(Ok(product));
            }

            return new JsonResult(BadRequest());
        }

        // Read
        [HttpGet]
        public JsonResult Read(int id)
        {
            var productInDb = _context.Products.Find(id);

            if (productInDb == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(productInDb));
        }

        // Read all
        [HttpGet()]
        public JsonResult ReadAll(string filter)
        {
            var productsInDb = _context.Products.ToList();

            return new JsonResult(Ok(productsInDb));
        }

        // Update
        [HttpPut]
        public JsonResult Update(Product product)
        {
            var productInDB = _context.Products.Find(product.Id);

            if (productInDB == null)
            {
                return new JsonResult(NotFound());
            }

            productInDB.Name = product.Name;
            productInDB.PotSize = product.PotSize;
            productInDB.PlantHeight = product.PlantHeight;
            productInDB.Colour = product.Colour;
            productInDB.ProductGroup = product.ProductGroup;

            _context.SaveChanges();

            return new JsonResult(Ok(product));
        }

        // Delete
        [HttpDelete] 
        public JsonResult Delete(int id)
        {
            var productInDB = _context.Products.Find(id);

            if (productInDB == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Products.Remove(productInDB);

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }
}
