using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly AllDbContext context;
        public ElevatorController(AllDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElevatorLogAccess>>> Get()
        {

            return await context.ElevatorLogs.ToListAsync();

        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<ElevatorLogAccess>> Get([FromRoute] int id)
        {
            var result = await context.ElevatorLogs.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]

        public async Task<IActionResult> addEmployee(AddElevator addelevator)
        {
           if(addelevator == null)
            {
                return BadRequest();
            }
            ElevatorLogAccess e = new ElevatorLogAccess();
            e.weight=addelevator.weight;
            e.floorno=addelevator.floorno;
            e.dateTime = DateTime.Now;
            

           await context.ElevatorLogs.AddAsync(e);
            await context.SaveChangesAsync();

            return Ok(e);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var eleSearch = await context.ElevatorLogs.FirstOrDefaultAsync(x=>x.Id == id);

            if (eleSearch != null)
            {
                // Remove from the storage
                context.Remove(eleSearch);
                // saves the result to the database
                await context.SaveChangesAsync();
            }

            return Ok(eleSearch);



        }
    }

    
}
