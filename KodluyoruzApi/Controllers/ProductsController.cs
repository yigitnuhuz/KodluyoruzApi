using System.Collections.Generic;
using System.Linq;
using KodluyoruzApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var storeProducts = Store.Products;
            //todo db den ürünleri çek
            return storeProducts;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct([FromRoute] int id)
        {
            var storeProduct = Store.Products.FirstOrDefault(p => p.Id == id);
            //todo db den ürünü çek

            if (storeProduct == null)
            {
                return NotFound("Ürün bulunamadı!");
            }

            return storeProduct;
        }


        [HttpPost]
        public ActionResult<bool> CreateProduct([FromBody] CreateProduct model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Ürün adı boş olamaz!");
            }

            if (model.Price <= 0)
            {
                return BadRequest("Ürün fiyatı 0'dan büyük olmalı!");
            }

            //todo servis ve db işlemleri yapılır

            return true;
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct([FromRoute]int id, [FromBody]UpdateProduct model)
        {
            var storeProduct = Store.Products.FirstOrDefault(p => p.Id == id);

            if (storeProduct == null)
            {
                return NotFound("Ürün bulunamadı!");
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Ürün adı boş olamaz!");
            }

            if (model.Price <= 0)
            {
                return BadRequest("Ürün fiyatı 0'dan büyük olmalı!");
            }

            //todo db üzerinde güncelleme yapılır.

            storeProduct.Name = model.Name;
            storeProduct.Price = model.Price;

            return Ok(storeProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteProduct([FromRoute] int id)
        {
            var storeProduct = Store.Products.FirstOrDefault(p => p.Id == id);
            //todo db den ürünü çek

            if (storeProduct == null)
            {
                return NotFound("Ürün bulunamadı!");
            }

            //todo db üzerinden sil

            return Ok(true);
        }

    }
}
