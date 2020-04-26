using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public int CityId { get; set; }
        public City City { get; set; }

    }
}