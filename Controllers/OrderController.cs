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
	public class OrderController : BaseController
	{
		#region custom
		#endregion
		#region generated
		ILogger Logger;
		public OrderController(ILogger<OrderController> logger){
			Logger = logger;
		}

		[HttpGet("/orders/{orderId}")]
		public ActionResult Order(int orderId){
			return Json(Handholder.GetOrder(orderId));
		}

		[HttpGet("/orders")]
		public ActionResult Index(){
			return Json(Handholder.GetOrders());
		}

		[HttpPost("/orders/{orderId}/delete")]
		public ActionResult DeleteOrder(int orderId){

			Logger.LogInformation("Delete Order: " + orderId);
			ShitBucket sBucket = new ShitBucket();
			Handholder.DeleteOrder(sBucket, orderId);
			if(!sBucket.IsValid){
				Logger.LogError(sBucket.GetTopError());
			}

			return Json(new{success = true});
		}

		[HttpPost("/orders/AddEdit")]
		public ActionResult AddEditOrder([FromBody]Order order){
			if(order.OrderId == 0){
				Logger.LogInformation("Adding new order");
			}
			else{
				Logger.LogInformation("Updating Order: " + order.OrderId);
			}

			ShitBucket sBucket = new ShitBucket();
			Handholder.AddEditOrder(sBucket, order);
			if(!sBucket.IsValid){
				Logger.LogError(sBucket.GetTopError());
			}
			return Json(order);
		}

		#endregion
	}

}
