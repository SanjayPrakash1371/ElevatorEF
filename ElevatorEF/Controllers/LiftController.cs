using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftController : ControllerBase  
    {
        private readonly AllDbContext context;
        public LiftController(AllDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiftLog>>> Get()
        {

            var result= await context.LiftLogs.ToListAsync();

            result.ForEach(list=>list.employee=context.Employees.Find(list.empId));

          //  return await context.LiftLogs.ForEachAsync(list=>list.employee=context.Employees.Find(keyValues: list.empId));

            return Ok(result);

        }

        [HttpGet]
        [Route("{id}")]
        public  async Task<ActionResult<LiftLog>> Get([FromRoute] int id)
        {
            LiftLog? result= await context.LiftLogs.FindAsync(id);

            Employee? employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == result.empId);

            result.employee = employee;


            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<LiftLog>> Post(NewLog newlog)
        {
            if(newlog== null)
            {
                return BadRequest();
            }
            LiftLog log = new LiftLog();
            log.empId = newlog.empId;
            log.start=newlog.start;
            log.end=newlog.end;
            log.dateTime = DateTime.Now;

            var emp=await context.Employees.FirstOrDefaultAsync(x=>x.Id==newlog.empId);
            log.employee = emp;

           await context.LiftLogs.AddAsync(log);
            await context.SaveChangesAsync();

            return Ok(log);
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var result=await context.LiftLogs.FirstOrDefaultAsync(l=>l.id==id);   

            if(result==null)
            {
                return NotFound();
            }

             context.Remove(result);
            await context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<LiftLog>> updateLog([FromRoute]int id, NewLog newlog)
        {
            context.Update(newlog);
            await context.SaveChangesAsync();

            return Ok(newlog);
        }
    }
}
