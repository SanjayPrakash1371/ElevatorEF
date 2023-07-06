using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;

namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogfinderCOntroller : ControllerBase
    {
        private readonly AllDbContext context;

        public LogfinderCOntroller(AllDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElevatorLogDI>>> Get()
        {
            var result= await context.elevatorLoggings.ToListAsync();

            result.ForEach(x => {
               
              //  x.liftlog.employee = context.Employees.FirstOrDefault(y => y.Id == x.liftlog.empId);
                x.liftlog = context.LiftLogs.Find(x.logLiftId);
                /* Employee? emp= new Employee();
                 emp = context.Employees.Find(x?.liftlog?.empId);
                 //
                 if(x.liftlog.empId!=null&&EmployeeAvailable((int)x.liftlog.empId)) {
                     x.liftlog.employee = emp;
                 }*/
                /* x.liftlog.employee = context.Employees.FirstOrDefault(y => y.Id == x.liftlog.empId);*/
                x.ElevatorLogAccess = context.ElevatorLogs.Find(x.elogId);

            });
            return Ok(result);
        }
        private bool EmployeeAvailable(int id)
        {
            return (context.Employees?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ElevatorLogDI>> getById([FromRoute] int id)
        {
            var result = await context.elevatorLoggings.FirstOrDefaultAsync(x => x.Id == id);
            result.liftlog = context.LiftLogs.FirstOrDefault(x => x.id == result.logLiftId);
            result.liftlog.employee = context.Employees.FirstOrDefault(x => x.Id == result.liftlog.empId);
            result.ElevatorLogAccess= context.ElevatorLogs.FirstOrDefault(x=>x.Id == result.elogId);    

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> add(CurrentLog log)
        {
            ElevatorLogDI di = new ElevatorLogDI();
            di.logLiftId = log.logId;
            di.elogId = log.elevatorLogId;
            LiftLog? logger= context.LiftLogs.FirstOrDefault(x => x.id == log.logId);
            di.liftlog = logger;

            ElevatorLogAccess? access = context.ElevatorLogs.FirstOrDefault(x => x.Id == log.elevatorLogId);
            di.ElevatorLogAccess = access;

            await context.elevatorLoggings.AddAsync(di);
            await context.SaveChangesAsync();

            //LiftLog? newLog = context.LiftLogs.FirstOrDefault(x=>x.id == log.logId);


            return Ok(di);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var result = await context.elevatorLoggings.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                // Remove from the storage
                context.Remove(result);
                // saves the result to the database
                await context.SaveChangesAsync();
            }

            return Ok(result);

            
        }

    }
}
