using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Temperature
    {
        public int Id { get; set; }
        public int PhotonId { get; set; }
        public string TempData { get; set; }
        public DateTime Time { get; set; }
    }
}