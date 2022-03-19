using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVP
{
    public class GuestResponse
    {
        public int GuestResponseID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public DateTime RegDate { get; set; }


        public GuestResponse() { }

        public GuestResponse(string name, string email, string phone, bool? willAttend)
        {
            Name = name;
            Email = email;
            Phone = phone;
            WillAttend = willAttend;
            RegDate = DateTime.Now;
        }
    }
}