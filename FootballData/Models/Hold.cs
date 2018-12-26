using System;
using System.Collections.Generic;
using System.Text;

namespace FootballData.Models
{
    public class Hold
    {
        public int ID { get; set; }
        public virtual StadiumAsset StadiumAsset { get;set;}
        public virtual StadiumCard StadiumCard { get; set; }
        public DateTime HoldPlaced { get; set; }

    }
}
