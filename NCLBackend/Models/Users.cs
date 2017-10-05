using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCLBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string POSITION { get; set; }
    }
}
