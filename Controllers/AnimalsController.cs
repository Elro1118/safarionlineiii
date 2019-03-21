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

  public class AnimalsController : ControllerBase
  {
    private DatabaseContext db;
    public AnimalsController()
    {
      this.db = new DatabaseContext();
    }


    [HttpGet]
    public ActionResult<IEnumerable<SeenAnimals>> GetAllAnimal()
    {

      var result = db.SeenAnimals.OrderBy(o => o.Species).ToList();
      return result;
    }
    [HttpGet("{species}")]
    public ActionResult<IEnumerable<SeenAnimals>> GetOneAnimal(string species)
    {

      var result = db.SeenAnimals.Where(w => w.Species == species).ToList();
      return result;
    }

    // [HttpGet("{location}")]
    // public ActionResult<IEnumerable<SeenAnimals>> GetAnimalsForLocation(string location)
    // {
    //   var result = db.SeenAnimals.Where(w => w.LocationOfLastSeen == location).ToList();
    //   return result;
    // }

    [HttpPost]
    public ActionResult<SeenAnimals> AddAnimal([FromBody] SeenAnimals animalToAdd)
    {

      db.SeenAnimals.Add(animalToAdd);
      db.SaveChanges();
      return animalToAdd;
    }




  }


}