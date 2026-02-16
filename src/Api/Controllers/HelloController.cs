using Microsoft.AspNetCore.Mvc;
using Api.Models;


namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    // GET: /api/hello
    [HttpGet]
    public string Get()
    {
        return "Hello from a controller!";
    }

    // GET: /api/hello/greet?name=Jim
    [HttpGet("greet")]
    public string Greet([FromQuery] string name)
    {
        return $"Hello {name}";
    }

    // GET: /api/hello/5
    [HttpGet("{id}")]
    public string GetById(int id)
    {
        return $"You requested id {id}";
    }

    // POST: /api/hello
    [HttpPost]
    public IActionResult Post([FromBody] MessageRequest request)
    {
        return Ok(new
        {
            Received = request.Message,
            Length = request.Message?.Length
        });
    }

    [HttpPost("person")]
    public IActionResult PostPerson([FromBody] Person person)
{
    // Example "strongly typed" usage
    var fullName = $"{person.FirstName} {person.LastName}".Trim();

    return Ok(new
    {
        FullName = fullName,
        person.Age,
        IsAdult = person.Age >= 18
    });
}


}

public class MessageRequest
{
    public string? Message { get; set; }
}
