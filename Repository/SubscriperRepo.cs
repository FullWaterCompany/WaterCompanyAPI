using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Repository
{
    public class SubscriperRepo : General<Subscriber>
    {
        waterComapnyContext db;

        public SubscriperRepo(waterComapnyContext _db)
        {
            db = _db;
        }

        public ActionResult<List<Subscriber>> GetAll()
        {
            List<Subscriber> subscripers = db.Subscribers.ToList();
            if (subscripers == null)
                return new StatusCodeResult(404);
            else return subscripers;
        }

        public ActionResult<Subscriber> GetById(string id)
        {
            Subscriber sub = db.Subscribers.FirstOrDefault(e => e.Id == id);
            if (sub == null)
                return new StatusCodeResult(404);
            else return sub;

        }

        public ActionResult<Subscriber> Delete(string id)
        {
            Subscriber sub = db.Subscribers.FirstOrDefault(e => e.Id == id);
            if (sub == null)
                return new StatusCodeResult(404);
            else
            {
                db.Subscribers.Remove(sub);
                db.SaveChanges();
                return sub;
            }

        }

        public ActionResult<Subscriber> Add(Subscriber t)
        {
            if (t == null) return new StatusCodeResult(400);
            else
            {
                db.Subscribers.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public ActionResult<Subscriber> Update(string id, Subscriber t)
        {
            Subscriber oldSub = db.Subscribers.FirstOrDefault(e => e.Id == id);
            if (oldSub == null)
                return new StatusCodeResult(404);
            else
            {
                oldSub.Name = t.Name;
                oldSub.Area = t.Area;
                oldSub.City = t.City;
                oldSub.Mobile = t.Mobile;
                oldSub.Notes = t.Notes;
                db.SaveChanges();
                return oldSub;
            }



        }


    }
}
