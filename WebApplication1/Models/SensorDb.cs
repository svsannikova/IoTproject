using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SensorDb:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photon> Photons { get; set; }
        public DbSet<Motion> Motions { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Raspi> Raspis { get; set; }

        public SensorDb():base("MyConnectionString")
        {
            
        }
    }
}