using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    // GET: api/users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.GetAll();
        return Ok(users);
    }

    // POST: api/users
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        var result = _service.Add(user);
        return Ok(result);
    }

    // GET: api/users/1
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _service.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}
