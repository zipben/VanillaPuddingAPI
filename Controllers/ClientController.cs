using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VanillaPuddingAPI.DAL;
using VanillaPuddingAPI.Models;

namespace VanillaPuddingAPI.Controllers
{
    public class ClientController : BaseController
    {
        ILogger Logger;

        public ClientController(ILogger<ClientController> logger){
            Logger = logger;
        }

        [HttpGet("/clients/{clientId}")]
        public ActionResult Client(int clientId){
            return Json(Handholder.GetClient(clientId));
        }

        [HttpGet("/clients")]
        public ActionResult Index(){
            return Json(Handholder.GetClients());
        }

        [HttpPost("/clients/AddEdit")]
        public ActionResult AddEditClient(Client client){
            
            if(client.ClientId == 0){
                Logger.LogInformation("Adding new client");
            }
            else{
                Logger.LogInformation("Updating Client: " + client.ClientId);
            }
            
            ShitBucket sBucket = new ShitBucket();
            Handholder.AddEditClient(sBucket, client);

            if(!sBucket.IsValid){
                Logger.LogError(sBucket.GetTopError());
            }
            
            return Json(new {success = sBucket.IsValid});
        }
    }
}
