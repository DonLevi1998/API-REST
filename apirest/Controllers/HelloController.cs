using apirest.Data;
using apirest.Models;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly AppDbContext _context;

    public HelloController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var saludo = new Hello { Message = "¡Hello World!" };
        _context.Hello.Add(saludo);
        _context.SaveChanges();

        return Ok(_context.Hello.ToList());
    }

    [HttpPost]
    public IActionResult Post([FromBody] string nombre)
    {
        var saludo = new Hello { Message = $"¡Hello, {nombre}!" };
        _context.Hello.Add(saludo);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = saludo.Id }, saludo);
    }
}
