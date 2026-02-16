using Microsoft.AspNetCore.Mvc;

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
}

public class MessageRequest
{
    public string? Message { get; set; }
}
