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

        public ContactController(ILogger<ContactController> logger){
            Logger = logger;
        }

        [HttpGet("/contacts/{contactId}")]
        public ActionResult Contact(int contactId){
            return Json(Handholder.GetContact(contactId));
        }

        [HttpGet("/contacts")]
        public ActionResult Index(){
            return Json(Handholder.GetContacts());
        }

        [HttpPost("/contacts/AddEdit")]
        public ActionResult AddEditContact([FromBody]Contact contact){
            
            if(contact.ContactId == 0){
                Logger.LogInformation("Adding new Contact");
            }
            else{   
                Logger.LogInformation("Updating Contact: " + contact.ContactId);
            }
            
            ShitBucket sBucket = new ShitBucket();
            Handholder.AddEditContact(sBucket, contact);

            if(!sBucket.IsValid){
                Logger.LogError(sBucket.GetTopError());
            }
            
            return Json(new {success = sBucket.IsValid});
        }
    }
}
