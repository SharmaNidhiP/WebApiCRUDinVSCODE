using Microsoft.AspNetCore.Mvc;
using WebApiCRUDSwagger.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApiCRUDSwagger.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
   
    private readonly  DataBaseFirstEfContext _DbContext;

    public PeopleController( DataBaseFirstEfContext dbContext)
    {
        this._DbContext = dbContext;
    }

    [HttpGet("GetAll")]
    public IActionResult Get()
    {
        var people=this._DbContext.Dbfirstapprtbls.ToList();
        return Ok(people);
    }

    [HttpGet("GetbyCode/{code}")]
    public IActionResult GetbyCode(int code)
    {
        var people=this._DbContext.Dbfirstapprtbls.FirstOrDefault(o=>o.Id==code);
        return Ok(people);
    }

     [HttpDelete("Remove/{code}")]
    public IActionResult Remove(int code)
    {
        var people=this._DbContext.Dbfirstapprtbls.FirstOrDefault(o=>o.Id==code);
        if(people!=null)
        {
            this._DbContext.Remove(people);
            return Ok(true);
        }
        return Ok(false);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] Dbfirstapprtbl _people)
    {
        var people=this._DbContext.Dbfirstapprtbls.FirstOrDefault(o=>o.Id==_people.Id);
        if(people!=null)
        {
            people.Name=_people.Name;
            people.Age=_people.Age;
            people.Gender=_people.Gender;
            people.Standard=_people.Standard;
            this._DbContext.SaveChanges();
        }
        else{
            this._DbContext.Dbfirstapprtbls.Add(_people);
            this._DbContext.SaveChanges();
        }
        return Ok(true);
    }
}
