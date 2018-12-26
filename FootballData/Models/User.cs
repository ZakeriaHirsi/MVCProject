using System;
using System.Collections.Generic;
using System.Text;

namespace FootballData.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Addresss { get; set; }
        public DateTime DOB{ get; set; }
        public string TelephoneNumber { get; set; }

        public virtual StadiumCard StadiumCard { get; set; }
        public virtual StadiumBranch StadiumBranch { get; set; }

    }
}
