using System;
using System.Collections.Generic;
using System.Ling;
using System.Threading.Tasks;
using Microsoft.Net.http.Headers;
using Microsoft.Data.SqlClient;

namespace mvc_Pratice.Controllers{
    public class LoginModel
    {
        public string? username{get; set;}

        public string? password{get; set;}
    }
}