using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    //[Route("api/[action]/{id?}")]
    //[Route("api/[controller]/[action]/{id?}")]
    [Route("api/[controller]/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        //[Route("customers")]
        //[Route("[controller]/all")]
        public IActionResult Index()
        {
            return View("MyView", new Result()
            {
                Controller = "CustomerController",
                Action = "Index"
            });
        }
        public IActionResult List(string id)
        {
            return View("MyView", new Result()
            {
                Controller = "CustomerController",
                Action = "List"
            });
        }
    }
}
