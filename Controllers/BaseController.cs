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
    public class BaseController : Controller
    {
        public DALHandholder Handholder;
        
        public BaseController(){
            Handholder = new DALHandholder();
        }
        protected ViewResult PageNotFound(){
            Response.StatusCode = 404;
            return View("PageNotFound");
        }
    }
}
