using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private DataContext _dataContext;

    public UsersController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>   GetUsers()
    {
        var users = await _dataContext.Users.ToListAsync();
        return users;
    }   

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUsersFromHell(int id)
    {
        return await _dataContext.Users.FindAsync(id);
    }

    [HttpGet("{id}/{idnotfound}")]
    public string GetUsersFromHeven(int id, string idnotfound)
    {
        var val = _dataContext.Users.Find(id);
        return "ID not found" + idnotfound +val.ToString();
    }


}
