using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        General<Invoice> repo;
        Iinvoice Iinvoice;
        public InvoiceController(General<Invoice> _repo, Iinvoice iinvoice)
        {
            repo = _repo;
            Iinvoice = iinvoice;
        }
        [HttpGet]
        public ActionResult<List<Invoice>> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Invoice> GetById(string id)
        {
            var data = repo.GetById(id);
            return data;

        }
        [HttpDelete("{id}")]
        public ActionResult<Invoice> Delete(string id)
        {
            var data = repo.Delete(id);
            return data;
        }
        [HttpPost]
        public ActionResult<Invoice> Add(Invoice Invoice)
        {
            var data = repo.Add(Invoice);
            return data.Value;
        }
        [HttpPut("{id}")]
        public ActionResult<Invoice> Update(string id, Invoice Invoice)
        {
            var data = repo.Update(id, Invoice);
            return data.Value;
        }
        [Route("[action]/{subscriptionNo}")]
        [HttpGet]
        public ActionResult<Invoice> GetInvoiceData(string subscriptionNo)
        {
            var data = Iinvoice.GetInoviceData(subscriptionNo);
            return data;
        }
    }
}
