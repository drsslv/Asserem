using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int AgentId { get; set; }
        public int PersonId { get; set; }
        public Agent Agent { get; set; }
        public Person Person { get; set; }


    }
}