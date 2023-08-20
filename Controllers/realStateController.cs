using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class realStateController : Controller
    {
        General<RealStateType> repo;
        public realStateController(General<RealStateType> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<RealStateType>> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<RealStateType> GetById(string id)
        {
            var data = repo.GetById(id);
            return data;

        }
        [HttpDelete("{id}")]
        public ActionResult<RealStateType> Delete(string id)
        {
            var data = repo.Delete(id);
            return data;
        }
        [HttpPost]
        public ActionResult<RealStateType> Add(RealStateType subscriber)
        {
            var data = repo.Add(subscriber);
            return data;
        }
        [HttpPut("{id}")]
        public ActionResult<RealStateType> Update(string id, RealStateType realState)
        {
            var data = repo.Update(id, realState);
            return data;
        }
    }
}
