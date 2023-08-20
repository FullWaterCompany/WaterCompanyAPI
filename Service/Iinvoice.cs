
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface Iinvoice
    {
        public ActionResult<Invoice> GetInoviceData(string id);
    }
}
