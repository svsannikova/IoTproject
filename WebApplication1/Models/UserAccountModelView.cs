using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Azure.Devices.Common;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class UserAccountViewModel
    {
        private SensorDb dbContext = new SensorDb();
        public User User { get; set; }
        public Photon Photon { get; set; }
        public Raspi Raspi { get; set; }
        public List<Light> Lights { get; set; }
        public List<Motion> Motions { get; set; }
        public List<Temperature> Temperatures { get; set; }

        public UserAccountViewModel(User user)
        {
            User = user;
            Photon = dbContext.Photons.FirstOrDefault(f => f.UserId == user.Id);
            Raspi = dbContext.Raspis.FirstOrDefault(f => f.UserId == user.Id);
            Lights = dbContext.Lights.Where(l => l.PhotonId == Photon.Id).ToList();
            Motions = dbContext.Motions.Where(l => l.PhotonId == Photon.Id).ToList();
            Temperatures = dbContext.Temperatures.Where(l => l.PhotonId == Photon.Id).ToList();
        }

        public UserAccountViewModel()
        {
            
        }

        public string ToShortForm(string data)
        {
            string output = data.Substring(0, data.Length - 4);
            return output;
        }
    }
}