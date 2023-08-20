
using global::WebApplication1.Models;
using global::WebApplication1.Service;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Repository
{
    public class realState_TypeRepo : General<RealStateType>
    {
        waterComapnyContext db;

        public realState_TypeRepo(waterComapnyContext _db)
        {
            db = _db;
        }

        public ActionResult<List<RealStateType>> GetAll()
        {
            List<RealStateType> realStates = db.RealStateTypes.ToList();
            if (realStates == null)
                return new StatusCodeResult(404);
            else return realStates;
        }

        public ActionResult<RealStateType> GetById(string id)
        {
            int ids = Int32.Parse(id);
            RealStateType realState = db.RealStateTypes.FirstOrDefault(e => e.Id == ids);
            if (realState == null)
                return new StatusCodeResult(404);
            else return realState;

        }

        public ActionResult<RealStateType> Delete(string id)
        {
            int ids = Int32.Parse(id);
            RealStateType realState = db.RealStateTypes.FirstOrDefault(e => e.Id == ids);
            if (realState == null)
                return new StatusCodeResult(404);
            else
            {
                db.RealStateTypes.Remove(realState);
                db.SaveChanges();
                return realState;
            }

        }

        public ActionResult<RealStateType> Add(RealStateType real)
        {
            if (real == null) return new StatusCodeResult(400);
            else
            {
                db.RealStateTypes.Add(real);

                db.SaveChanges();
                return real;
            }
        }

        public ActionResult<RealStateType> Update(string id, RealStateType t)
        {
            int ids = Int32.Parse(id);
            RealStateType oldrealState = db.RealStateTypes.FirstOrDefault(e => e.Id == ids);
            if (oldrealState == null)
                return new StatusCodeResult(404);
            else
            {
                oldrealState.Name = t.Name;
                oldrealState.Notes = t.Notes;
                db.SaveChanges();
                return oldrealState;
            }
        }
    }

}
