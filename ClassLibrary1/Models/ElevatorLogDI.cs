using ElevatorEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public  class ElevatorLogDI
    {
        public int Id { get; set; }

        public int floorno { get; set; }

        

        public int? elogId { get; set; }

        public int? logLiftId { get; set; }

        public LiftLog? liftlog { get; set; }

        public ElevatorLogAccess? ElevatorLogAccess { get; set; }
    }
}
