using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    private readonly ILogger<MyController> _logger;
    private readonly List<Student> _students;

    public MyController(ILogger<MyController> logger)
    {
        _logger = logger;
        // Initialize the student list in the constructor
        _students = new List<Student>
        {
            new Student { Id = 1, Name = "baburao" },
            new Student { Id = 2, Name = "niunj" },
            new Student { Id = 3, Name = "sam" }
        };
    }

    [HttpGet("greeting")]
    public IActionResult GetGreeting()
    {
        // Return the list of students from the field
        return Ok(_students);
    }

    [HttpGet("greeting/{id}")]
    public IActionResult GetGreetingById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound($"Student with Id {id} not found.");
        }
        return Ok(student);
    }

    [HttpGet("student/{id}")]
    public IActionResult GetStudent(int id)
    {
        var s = _students.FirstOrDefault(s => s.Id == id);
        if (s == null)
        {
            return NotFound($"Student with Id {id} not found.");
        }
        return Ok(s);
    }

    [HttpGet("person")]
    public IActionResult GetPerson()
    {
        var person = new
        {
            Name = "John Doe",
            Age = 30
        };
        return Ok(person);
    }
}