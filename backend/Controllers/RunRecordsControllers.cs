using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiController]
  public class RunRecordsController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public RunRecordsController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/foodrecords
    [HttpGet]
    public async Task<ActionResult<List<RunRecord>>> Get()
    {
      return await _dbContext.RunRecords.ToListAsync();
    }

    // GET api/foodrecords/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RunRecord>> Get(string id)
    {
      return await _dbContext.RunRecords.FindAsync(id);
    }

    // POST api/foodrecords
    [HttpPost]
    public async Task Post(RunRecord model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/foodrecords/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, RunRecord model)
    {
      var exists = await _dbContext.RunRecords.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.RunRecords.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/foodrecords/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
      var entity = await _dbContext.RunRecords.FindAsync(id);

      _dbContext.RunRecords.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}