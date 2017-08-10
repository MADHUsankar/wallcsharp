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
    public class PostcmtController : Controller
    {


[HttpPost]
 
[Route("processcmt")]
public IActionResult processcmt(Commentpost newCommentpost)
{
  if(ModelState.IsValid)
        {
        // int? userid =  HttpContext.Session.GetInt32("uid");
        System.Console.WriteLine("cmt");
        System.Console.WriteLine(HttpContext.Session.GetInt32("uid"));
        
        int userid =  (int)HttpContext.Session.GetInt32("uid");
         System.Console.WriteLine("blog id =",newCommentpost.Messages_idMessages);
        string query = $"insert into comments (Commentscontent,User_idUser,Messages_idMessages,createdat,updatedat) VALUES ('{newCommentpost.Commentscontent}','{userid}','{newCommentpost.Messages_idMessages}',Now(),Now())";
        System.Console.WriteLine(query);
            DbConnector.Execute(query);

            return RedirectToAction("wall","Postmsg");

        }
            else{
            ViewBag.errors = ModelState.Values;
            ViewBag.status="msgfail";
            return View("Wall");

        }

}


    }
}