using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc_new.Models;
using Microsoft.Data.SqlClient;

namespace mvc_new.Controllers;

public class HomeController : Controller
{
    SqlConnection con = new SqlConnection();
    SqlCommand com = new SqlCommand();
    SqlDataReader? dr;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
    [HttpGet]
    public IActionResult login()
    {
        return View();
    }

    void connectionString(){
        con.ConnectionString = "data source = 192.168.1.240\\SQLEXPRESS; database=cad_ts; User ID = CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";
    }

    [HttpPost]
    public IActionResult VerifyLogin(LoginModel lmodel){
        connectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="SELECT * FROM ts_login WHERE User_Name='"+lmodel.username+"' AND Password='"+lmodel.password+"' ;";

        dr = com.ExecuteReader();
        if(dr.Read()){
            con.Close();
            return View("Success");
        }
        else{
            con.Close();
            return View("Error"); 
        }
    }

    public IActionResult signin()
    {
        return View();
    }
    [HttpPost]
     public IActionResult Register(RegisterModel rmodel)
    {
        connectionString();
        con.Open();
        com.Connection=con;
        string created_by=rmodel.FirstName+" "+rmodel.LastName;
         com.CommandText="insert into ts_signup (First_Name,Last_Name,Email_Address,Phone_Number,Password,Conform_Password,Created_By,Create_Time) values('"+rmodel.FirstName+"','"+rmodel.LastName+"','"+rmodel.EmailId+"','"+rmodel.PhoneNumber+"','"+rmodel.Password+"' ,'"+rmodel.ConformPassword+"','"+created_by+"','"+DateTime.Now+"');insert into ts_login (User_Name,Password ) values('"+rmodel.EmailId+"','"+rmodel.Password+"');";
        int row=com.ExecuteNonQuery();
        if(row>0)
        {
            return RedirectToAction("Login");
        }else{
            return View("Error");
        }
    
    
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

