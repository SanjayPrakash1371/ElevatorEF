using ElevatorEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ElevatorEF.DbContext
{
    public class AllDbContext:DbContext
    {
        public AllDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Elevator>  Elevators { get; set; }

        public  DbSet<LiftLog> LiftLogs { get; set; }
    }
}
