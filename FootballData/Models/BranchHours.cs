using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class BranchHours
    {

        public int ID { get; set; }
        public StadiumBranch Branch { get; set; }

        [Range(0, 6)]
        public int DayOfWeek { get; set; }

        [Range(0, 23)]
        public int OpenTime { get; set; }

        [Range(0, 23)]
        public int CloseTime { get; set; }
    }
}
