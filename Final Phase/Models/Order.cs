using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShoppingPortal.Models
{
    public class Order
    {
        public int id { get; set; }
        public User user { get; set; }
        public Item item { get; set; }
        public DateTime orderedTime { get; set; }
        public int buyerId { get; set; }
    }
}