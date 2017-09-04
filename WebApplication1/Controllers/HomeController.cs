using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using Microsoft.Azure.Devices;
using WebApplication1.Controllers;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        SensorDb sensorData = new SensorDb();

        [AllowAnonymous]
        public ActionResult UserCheck(string email, string pwd)
        {
            User user = sensorData.Users.FirstOrDefault(u => u.Email== email&&u.Password==pwd);
            if (user != null)
            {
                return RedirectToAction("PersonalAccount", "Home");

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }         
            
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = sensorData.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("PersonalAccount", "Home", user);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
               
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PersonalAccount(UserAccountViewModel model, int userId, int raspiId, bool pin1, bool pin2, bool pin3)
        {
            if (ModelState.IsValid)
            {
                Raspi raspi = new Raspi() {Pin1 = pin1, Pin2 = pin2, Pin3 = pin3, RaspiId = raspiId};
                    sensorData.Raspis.Attach(raspi);
                    sensorData.Entry(raspi).Property(x => x.Pin1).IsModified = true;
                    sensorData.Entry(raspi).Property(x => x.Pin2).IsModified = true;
                    sensorData.Entry(raspi).Property(x => x.Pin3).IsModified = true;
                    sensorData.SaveChanges();
                User myUser = sensorData.Users.FirstOrDefault(u => u.Id == userId);
                model= new UserAccountViewModel(myUser);               
                
                    return View(model);

            }

            return View(model);
        }
        public ActionResult PersonalAccount(User user)
        {
            UserAccountViewModel viewModel= new UserAccountViewModel(user);
            return View(viewModel);
        }
        public ActionResult SaveView(UserAccountViewModel model)
        {
            Raspi raspi = new Raspi() { Pin1 = model.Raspi.Pin1, Pin2 = model.Raspi.Pin2, Pin3 = model.Raspi.Pin3, RaspiId = model.Raspi.RaspiId };
            sensorData.Raspis.Attach(raspi);
            sensorData.Entry(raspi).Property(x => x.Pin1).IsModified = true;
            sensorData.Entry(raspi).Property(x => x.Pin2).IsModified = true;
            sensorData.Entry(raspi).Property(x => x.Pin3).IsModified = true;
            sensorData.SaveChanges();
            return RedirectToAction("PersonalAccount", "Home", model.User);
        }

        public ActionResult Register()
        {
            User newUser = new User();
            return View(newUser);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {                     
            return View();
        }
        public ActionResult CreateUser(User user)
        {
            return RedirectToAction("Login", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}