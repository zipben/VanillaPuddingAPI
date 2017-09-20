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
    public class ClientController : BaseController
    {
        public ActionResult Client(int clientId){

            Client client = new Client();

            using(var db = new Context()){
                client = db.Clients.Where(c => c.ClientId == clientId).FirstOrDefault();
            }

            if(client == null){
                return PageNotFound(); 
            }

            return Json(client);
        }

        public ActionResult Index(){
            List<Client> clients = new List<Client>();

            using(var db = new Context()){
                clients = db.Clients.ToList();
            }

            return Json(clients);
        }
    }
}
