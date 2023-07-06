using ElevatorEF.Models;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class AllDbContext : DbContext
    {
        public AllDbContext(DbContextOptions<AllDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ElevatorLogAccess> ElevatorLogs { get; set; }

        public DbSet<LiftLog> LiftLogs { get; set; }

        public DbSet<ElevatorLogDI> elevatorLoggings { get; set; }
    }
}
