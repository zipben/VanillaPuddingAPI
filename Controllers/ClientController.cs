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
        #region custom
        //this is a test
        //to make sure it doesnt get overwritten
        #endregion

		#region generated
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

		[HttpPost("/clients/{clientId}/delete")]
		public ActionResult DeleteClient(int clientId){

			Logger.LogInformation("Delete Client: " + clientId);
			ShitBucket sBucket = new ShitBucket();
			Handholder.DeleteClient(sBucket, clientId);
			if(!sBucket.IsValid){
				Logger.LogError(sBucket.GetTopError());
			}

			return Json(new{success = true});
		}

		[HttpPost("/clients/AddEdit")]
		public ActionResult AddEditClient([FromBody]Client client){
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
			return Json(client);
		}

		#endregion
	}

}
