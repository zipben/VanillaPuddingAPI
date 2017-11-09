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
    public class ContactController : BaseController
    {
        ILogger Logger;

        public ContactController(ILogger<ClientController> logger){
            Logger = logger;
        }

        [HttpGet("/contacts/{contactId}")]
        public ActionResult Contact(int contactId){
            return Json(Handholder.GetClient(contactId));
        }

        [HttpGet("/contacts")]
        public ActionResult Index(){
            return Json(Handholder.GetClients());
        }

        [HttpPost("/contacts/AddEdit")]
        public ActionResult AddEditContact([FromBody]Contact contact){
            
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
