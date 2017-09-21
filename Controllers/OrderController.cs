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
    public class OrderController : BaseController
    {
        [HttpGet("/orders/{orderId}")]
        public ActionResult Order(int orderId){

            Order order = new Order();

            using(var db = new Context()){
                order = db.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
            }

            if(order == null){
                return PageNotFound(); 
            }

            return Json(order);
        }

        [HttpGet("/orders")]
        public ActionResult Index(){
            List<Order> orders = new List<Order>();

            using(var db = new Context()){
                orders = db.Orders.ToList();
            }

            return Json(orders);
        }
    }
}
