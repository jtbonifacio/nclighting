﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCLBackend.Models
{
    public class Daily
    {
        public int Id { get; set; }
        public DateTime DATE { get; set; }
        public string SALES_REP { get; set; }
        public int SalesAmt { get; set; }

    }
}