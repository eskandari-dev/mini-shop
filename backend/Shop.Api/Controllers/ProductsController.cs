using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Mouse", Price = 250000m, Stock = 10},
        new Product { Id = 2, Name = "Keyboard", Price = 350000m, Stock = 20},
        new Product { Id = 3, Name = "Monitor", Price = 1500000m, Stock = 30},
        new Product { Id = 4, Name = "Headset", Price = 500000m, Stock = 40},
        new Product { Id = 5, Name = "Speaker", Price = 750000m, Stock = 50},
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        Product product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        product.Id = products.Max(p => p.Id) + 1;
        products.Add(product);
        return Ok(product);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updated)
    {
        Product product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = updated.Name;
        product.Price = updated.Price;
        product.Stock = updated.Stock;

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Product product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        products.Remove(product);
        return NoContent();
    }

}