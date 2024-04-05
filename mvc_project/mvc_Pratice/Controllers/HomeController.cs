using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc_Pratice.Models;
using Microsoft.Data.SqlClient;

namespace mvc_Pratice.Controllers;

public class HomeController : Controller
{
     SqlConnection con = new SqlConnection();
     SqlCommand com= new SqlCommand();
     SqlDataReader? dr;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]

    public IActionResult Login()
    {
        return View();
    }
     
    void connetionString(){
        con.ConnetionString ="data source= 192.168.1.240\SQLEXPRESS; database=cad_ts; User ID = CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";
    
    }
    [httpPost]
    public IActionResult VerifyLogin(LoginModel lmodel){
        connectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="SELECT * FROM TS_LOGIN"
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
     public IActionResult Service()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
