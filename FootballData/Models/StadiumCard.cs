using System;
using System.Collections.Generic;
using System.Text;

namespace FootballData.Models
{
    public class StadiumCard
    {
        public int ID { get; set; }
        public decimal Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }

    }
}
