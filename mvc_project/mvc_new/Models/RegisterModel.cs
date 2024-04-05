using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Microsoft.Data.SqlClient; 

namespace mvc_new.Controllers
{
    public class RegisterModel
    {
        public string? FirstName{get; set;}

        public string? LastName{get; set;}

        public string? EmailId {get; set;}

        public string? PhoneNumber{get; set;}

        public string? Password{get; set;}

        public string? ConformPassword{get; set;}
    }
}