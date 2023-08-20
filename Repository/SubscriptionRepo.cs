
using global::WebApplication1.Models;
using global::WebApplication1.Service;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Repository
{
    public class SubscriptionRepo : General<Subscription>
    {
        waterComapnyContext db;

        public SubscriptionRepo(waterComapnyContext _db)
        {
            db = _db;
        }

        public ActionResult<List<Subscription>> GetAll()
        {
            List<Subscription> Subscriptions = db.Subscriptions.ToList();
            if (Subscriptions == null)
                return new StatusCodeResult(404);
            else return Subscriptions;
        }

        public ActionResult<Subscription> GetById(string id)
        {
            Subscription Subscription = db.Subscriptions.FirstOrDefault(e => e.Id == id);
            if (Subscription == null)
                return new StatusCodeResult(404);
            else return Subscription;

        }

        public ActionResult<Subscription> Delete(string id)
        {
            Subscription Subscription = db.Subscriptions.FirstOrDefault(e => e.Id == id);
            if (Subscription == null)
                return new StatusCodeResult(404);
            else
            {
                db.Subscriptions.Remove(Subscription);
                db.SaveChanges();
                return Subscription;
            }

        }

        public ActionResult<Subscription> Add(Subscription t)
        {
            if (t == null) return new StatusCodeResult(400);
            else
            {
                db.Subscriptions.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public ActionResult<Subscription> Update(string id, Subscription t)
        {
            Subscription oldSub = db.Subscriptions.FirstOrDefault(e => e.Id == id);
            if (oldSub == null)
                return new StatusCodeResult(404);
            else
            {
                oldSub.UnitNo = t.UnitNo;
                oldSub.IsThereSanitation = t.IsThereSanitation;
                oldSub.LastReading = t.LastReading;
                oldSub.SubscriberCode = t.SubscriberCode;
                oldSub.RealStateType = t.RealStateType;
                oldSub.Notes = t.Notes;
                db.SaveChanges();
                return oldSub;
            }



        }


    }

}
