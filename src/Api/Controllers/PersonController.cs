using Microsoft.AspNetCore.Mvc;
using Api.Models;


namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { FileManager.Instance.Persons });
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person nPerson)
    {
        FileManager.Instance.Persons.Add(nPerson);

        return Ok(new
        {
            Recieved = nPerson
        });
    }

    [HttpPut]
    public IActionResult Put([FromBody] List<Person> nPersons)
    {
        FileManager.Instance.Persons = nPersons;
        return Ok(new
        {
            Reassigned = nPersons
        });
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        FileManager.Instance.Persons = new List<Person>();
        return Ok();
    }



    // GET: /api/person/getname?firstname=Jim
    [HttpGet("getname")]
    public Person? GetName([FromQuery] string firstName)
    {
        Person? want = null;
        foreach (Person p in FileManager.Instance.Persons)
        {
            if (p.FirstName == firstName)
            {
                want = p;
                break;
            }
        }

        return want;
    }

    [HttpPost("save")]
    public IActionResult Save()
    {
        FileManager.Instance.Save();

        return Ok(new
        {
            Saved = FileManager.Instance.Persons
        });
    }

    // GET: /api/person/5
    [HttpGet("{id}")]
    public Person? GetById(int id)
    {
        try
        {
            return FileManager.Instance.Persons.ElementAt(id);
        }
        catch
        {
            return null;
        }

    }
}

public class MessageRequest
{
    public string? Message { get; set; }
}
