using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCLBackend.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ITEM { get; set; }
        public string ITEM_DESC { get; set; }
        public int ON_HAND_QTY { get; set; }
        public string STATUS { get; set; }
        public int PRICE { get; set; }
        public string IMAGE { get; set; }
    }
}
