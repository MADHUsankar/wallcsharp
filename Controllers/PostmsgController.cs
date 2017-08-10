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
    public class PostmsgController : Controller
    {

[HttpGet]
 
[Route("wall")]
public IActionResult wall()
{
    ViewBag.username = HttpContext.Session.GetString("username");
    System.Console.WriteLine("wall");
    System.Console.WriteLine(HttpContext.Session.GetInt32("uid"));
    string readq = "SELECT * FROM messages m join user u on m.user_iduser = u.iduser order  by m.createdat desc";
            var allmessagess =  DbConnector.Query(readq);
            ViewBag.allmessagess = allmessagess;
                string readc = "SELECT * FROM comments c join user u on c.user_idUser=u.idUser order  by c.createdat desc";
            var allcomments =  DbConnector.Query(readc);
            ViewBag.allcomments = allcomments;

    return View("success");
}


[HttpPost]
 
[Route("processmessage")]
public IActionResult processmessage(Messagepost newMessagepost)
{
  if(ModelState.IsValid)
        {
        // int? userid =  HttpContext.Session.GetInt32("uid");
        System.Console.WriteLine("msg");
        System.Console.WriteLine(HttpContext.Session.GetInt32("uid"));
        int userid =  (int)HttpContext.Session.GetInt32("uid");
       
        string query = $"insert into messages (Messagescontent,User_idUser,createdat,updatedat) VALUES ('{newMessagepost.Messagescontent}','{userid}',Now(),Now())";
        System.Console.WriteLine(query);
            DbConnector.Execute(query);

            return RedirectToAction("wall");

        }
            else{
            ViewBag.errors = ModelState.Values;
            ViewBag.status="msgfail";
            return View("success");

        }

}

[HttpGet]
[Route("logout")]
public IActionResult logout()
{
 HttpContext.Session.Clear();
 return RedirectToAction("Index","Register");

}

    }
}