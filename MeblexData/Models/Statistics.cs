using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class Statistics
    {
        public int AmountOfOrders { get; set; }
        public int AmountOfShippedOrders { get; set; }
        public int AmountOfNotShippedOrders { get; set; }
        public int AmountOfSoldMebels { get; set; }
        public decimal AmountOfMoneyEarned { get; set; }

    }
}
