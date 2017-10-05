using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCLBackend.Models
{
    public class Quotas
    {
        public int Id { get; set; }
        public string SALES_REP { get; set; }
        public int YEARLY_QUOTA { get; set; }
        public int MONTHLY_QUOTA { get; set; }
        public string REPNAME { get; set; }

    }
}
