using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Motion
    {
        public int Id { get; set; }
        public int PhotonId { get; set; }
        public string MotionData { get; set; }
        public DateTime Time { get; set; }
    }
}