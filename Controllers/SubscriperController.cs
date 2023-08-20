using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriperController : Controller
    {
        General<Subscriber> repo;
        public SubscriperController(General<Subscriber> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<Subscriber>> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Subscriber> GetById(string id)
        {
            var data = repo.GetById(id);
            return data;

        }
        [HttpDelete("{id}")]
        public ActionResult<Subscriber> Delete(string id)
        {
            var data = repo.Delete(id);
            return data;
        }
        [HttpPost]
        public ActionResult<Subscriber> Add(Subscriber subscriber)
        {
            var data = repo.Add(subscriber);
            return data;
        }
        [HttpPut("{id}")]
        public ActionResult<Subscriber> Update(string id, Subscriber subscriber)
        {
            var data = repo.Update(id, subscriber);
            return data;
        }
    }
}
