using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB_ASPNET.Models
{
    public class Customer
    {
        public string Fullname { get; set; }
        public DateTime BirthDay { get; set; }
        public int yearOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string CCDD { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
    }
}