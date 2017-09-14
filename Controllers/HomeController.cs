using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VanillaPuddingAPI.DAL;
using VanillaPuddingAPI.Models;

namespace VanillaPuddingAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new Context()){
                db.Clients.Add(new Client(){Name = "Bobula"});
                db.SaveChanges();

                //Dick
                
                var query = from b in db.Clients select b;

                foreach(var item in query){
                    Console.WriteLine(item.Name);
                }
            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
