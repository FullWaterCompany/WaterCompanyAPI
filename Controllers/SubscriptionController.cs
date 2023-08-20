using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        General<Subscription> repo;
        public SubscriptionController(General<Subscription> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<Subscription>> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Subscription> GetById(string id)
        {
            var data = repo.GetById(id);
            return data;

        }
        [HttpDelete("{id}")]
        public ActionResult<Subscription> Delete(string id)
        {
            var data = repo.Delete(id);
            return data;
        }
        [HttpPost]
        public ActionResult<Subscription> Add(Subscription sub)
        {
            var data = repo.Add(sub);
            return data;
        }
        [HttpPut("{id}")]
        public ActionResult<Subscription> Update(string id, Subscription sub)
        {
            var data = repo.Update(id, sub);
            return data;
        }
    }
}
