using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Microsoft.Data.SqlClient; 

namespace mvc_new.Controllers
{
    public class LoginModel
    {
        public string? username{get; set;}

        public string? password{get; set;}
    }
}