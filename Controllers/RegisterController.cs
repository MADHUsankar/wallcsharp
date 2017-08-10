using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using login.Connectors;
using login.Models;
using System.Linq;

namespace login.Controllers
{
    public class RegisterController : Controller
    {
        
[HttpGet]
 
[Route("")]
        public IActionResult Index()
        {
            return View("Register");

        }
 

// A POST method
[HttpPost]
[Route("processlogin")]
public IActionResult processlogin(loginUser newloginUser)
{
    if(ModelState.IsValid)
    {
        string userexistsq = $"SELECT * FROM user where EmailAddress='{newloginUser.EmailAddress}'";
        System.Console.WriteLine(userexistsq);
         Dictionary<string, object> userexists =  DbConnector.Query(userexistsq).SingleOrDefault();
        if (userexists == null)
            {
                                       ViewBag.status="loginfailspecific";
                        ViewBag.loginerror = "Please register!";
            return View("Register");
        }
        else
        {
            System.Console.WriteLine("started");
            System.Console.WriteLine(userexists["Password"]);
            System.Console.WriteLine(newloginUser.Password);
            if ((string)userexists["Password"] == newloginUser.Password){
                HttpContext.Session.SetInt32("uid",(int)userexists["idUser"]);
                System.Console.WriteLine("test");
                System.Console.WriteLine(HttpContext.Session.GetInt32("uid"));
                
                HttpContext.Session.SetString("username", (string)userexists["FirstName"]);
                return RedirectToAction("wall","Postmsg");
                }
            else{
                 ViewBag.status="loginfailspecific";
                        ViewBag.loginerror = "Invalid Credentials!";
            return View("Register");
            }

        }
    }
    else{
            ViewBag.errors = ModelState.Values;
            ViewBag.status="loginfail";
            return View("Register");
        }
}
[HttpPost]
[Route("processuser")]
public IActionResult processuser(User newuser)
{
    if(ModelState.IsValid)
    {
        string userexistsq = $"SELECT * FROM user where EmailAddress='{newuser.EmailAddress}'";
         List<Dictionary<string, object>> userexists =  DbConnector.Query(userexistsq);
        if (userexists.Count == 0)
        {
         string query = $"insert into user (FirstName,LastName,Age,EmailAddress,Password) VALUES ('{newuser.FirstName}','{newuser.LastName}','{newuser.Age}','{newuser.EmailAddress}','{newuser.Password}')";
        DbConnector.Execute(query);
        HttpContext.Session.SetString("username", newuser.FirstName);
        
        return RedirectToAction("wall","Postmsg");
        }
        else
        {
                    ViewBag.status="regfailspecific";
                    ViewBag.regerror = "User already exists";
        return View("Register");
        }
    }
    else{
        ViewBag.errors = ModelState.Values;
        ViewBag.status="regfail";
        return View("Register");

    }
}
    }
}