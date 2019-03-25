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

    [HttpGet("{location}")]
    public ActionResult<IEnumerable<SeenAnimals>> GetAnimalsForLocation(string location)
    {
      var result = db.SeenAnimals.Where(w => w.LocationOfLastSeen == location).ToList();
      return result;
    }

    [HttpGet("TotalSeenAnimals")]
    public ActionResult<int> GetTotalSeenAnimals()
    {
      var result = db.SeenAnimals.Sum(s => s.CountOfTimesSeen);
      return result;
    }

    [HttpGet("Places")]
    public ActionResult<List<string>> GetAllPlace()
    {
      var result = db.SeenAnimals.Select(s => s.LocationOfLastSeen).Distinct().ToList();
      return result;
    }

    [HttpGet("ThreeAnimalsTotal")]
    public ActionResult<int> GetThreeAnimalsTotal([FromQuery] string specie, string specie2, string specie3)
    {
      var animalsTotal = db.SeenAnimals.Where(w => w.Species == specie || w.Species == specie2 || w.Species == specie3);
      var result = animalsTotal.Sum(s => s.CountOfTimesSeen);
      return result;
    }


    [HttpPost]
    public ActionResult<SeenAnimals> AddAnimal([FromBody] SeenAnimals animalToAdd)
    {
      db.SeenAnimals.Add(animalToAdd);
      db.SaveChanges();
      return animalToAdd;
    }


    [HttpPut("{id}")]
    public ActionResult<IEnumerable<SeenAnimals>> UpdateAnimal(int id)
    {
      var sawAnimal = db.SeenAnimals.Where(w => w.Id == id).ToList();
      foreach (var item in sawAnimal)
      {
        item.CountOfTimesSeen += 1;
      }
      db.SaveChanges();
      sawAnimal = db.SeenAnimals.Where(w => w.Id == id).ToList();
      return sawAnimal;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimalId(int id)
    {
      var animal = db.SeenAnimals.FirstOrDefault(f => f.Id == id);
      db.SeenAnimals.Remove(animal);
      db.SaveChanges();
      return Ok();
    }

    [HttpDelete("location={location}")]
    public ActionResult DeleteAnimalLocation(string location)
    {
      var animal = db.SeenAnimals.Where(w => w.LocationOfLastSeen == location);
      db.SeenAnimals.RemoveRange(animal);
      db.SaveChanges();
      return Ok();
    }


  }


}