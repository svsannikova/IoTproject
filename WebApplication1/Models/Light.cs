using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Light
    {
        public int Id { get; set; }
        public int PhotonId { get; set; }
        public string LightData { get; set; }
        public DateTime Time { get; set; }
    }
}