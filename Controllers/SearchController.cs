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
    private DatabaseContext db;
    public SearchController()
    {
      this.db = new DatabaseContext();
    }

    // We wanna do a GET to /api/search?query=Lions
    [HttpGet]
    public ActionResult<IEnumerable<SeenAnimals>> GetAllAnimals([FromQuery] string specie, string specie2, string specie3)
    {
      var result = db.SeenAnimals.Where(w => w.Species == specie || w.Species == specie2 || w.Species == specie3).ToList();
      return result;
    }
  }
}