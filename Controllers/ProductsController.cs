using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<string> products = new List<string>
    {
        "Product 1",
        "Product 2",
        "Product 3"
    };

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetProducts()
    {
        return Ok(products);
    }
}
