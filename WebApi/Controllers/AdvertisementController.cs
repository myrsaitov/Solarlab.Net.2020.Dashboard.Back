using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер объявлений
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}