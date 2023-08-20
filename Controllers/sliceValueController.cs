using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sliceValueController : Controller
    {
        General<SliceValue> repo;
        public sliceValueController(General<SliceValue> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<SliceValue>> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<SliceValue> GetById(string id)
        {
            var data = repo.GetById(id);
            return data;

        }
        [HttpDelete("{id}")]
        public ActionResult<SliceValue> Delete(string id)
        {
            var data = repo.Delete(id);
            return data;
        }
        [HttpPost]
        public ActionResult<SliceValue> Add(SliceValue slice)
        {
            var data = repo.Add(slice);
            return data;
        }
        [HttpPut("{id}")]
        public ActionResult<SliceValue> Update(string id, SliceValue slice)
        {
            var data = repo.Update(id, slice);
            return data;
        }
    }
}
