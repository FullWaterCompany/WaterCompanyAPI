using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface General<t>
    {
        ActionResult<List<t>> GetAll();
        ActionResult<t> GetById(string id);
        ActionResult<t> Delete(string id);
        ActionResult<t> Add(t t);
        ActionResult<t> Update(string id,t t);

    }
}
