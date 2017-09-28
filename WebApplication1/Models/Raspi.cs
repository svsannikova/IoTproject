using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Devices;

namespace WebApplication1.Models
{
    public class Raspi
    {
        [Display(Name = "Raspberry Pi")]
        public int RaspiId { get; set; }
        public int UserId { get; set; }

        private bool pin1;
       
        public bool Pin1
        {
            get { return pin1; }
            set
            {
                
                SendMessageToPi(1, value);
                pin1 = value;
            }
        }
        private bool pin2;

        public bool Pin2
        {
            get { return pin2; }
            set

            {
                SendMessageToPi(4, value);
                pin2 = value;
            }
        }

        private bool pin3;

        public bool Pin3
        {
            get { return pin3; }
            set
            {
                SendMessageToPi(5, value);
                pin3 = value;
            }
        }


        public void SendMessageToPi(int pin, bool state)
        {
            string parameter = pin.ToString() + state.ToString().ToLower();
            string address =
                "https://firstprojecttest.scm.azurewebsites.net/api/triggeredwebjobs/connectionToPi/run?arguments=" +
                parameter;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(address);
            request.Method = "POST";
            var byteArray = Encoding.ASCII.GetBytes("svsannik:*******");
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.ContentLength = 0;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {

            }
        }

    }
}
