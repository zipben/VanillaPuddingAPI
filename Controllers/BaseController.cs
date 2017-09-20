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
    public class BaseController : Controller
    {
        protected ViewResult PageNotFound(){
            Response.StatusCode = 404;
            return View("PageNotFound");
        }
    }
}
