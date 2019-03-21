using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using safarionlineiii.Modal;

namespace safarionlineiii.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    // We wanna do a GET to /api/search?query=Lions
    [HttpGet]
    public ActionResult<string> GetAllAnimals([FromQuery] string query)
    {
      return query;
    }


  }
}