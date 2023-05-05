using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BD_Admin.Model
{
    internal class OrderSplit
    {
        public int Id { get; set; }
        public decimal OrderPrice { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public bool IsOrderCompleted { get; set; }
    }
}
