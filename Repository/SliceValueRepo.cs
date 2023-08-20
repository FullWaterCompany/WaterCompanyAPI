using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Repository
{
    public class SliceValueRepo : General<SliceValue>
    {
        waterComapnyContext db;

        public SliceValueRepo(waterComapnyContext _db)
        {
            db = _db;
        }

        public ActionResult<List<SliceValue>> GetAll()
        {
            List<SliceValue> slices = db.SliceValues.ToList();
            if (slices == null)
                return new StatusCodeResult(404);
            else return slices;
        }

        public ActionResult<SliceValue> GetById(string id)
        {
            int ids = Int32.Parse(id);
            SliceValue slice = db.SliceValues.FirstOrDefault(e => e.Id == ids);
            if (slice == null)
                return new StatusCodeResult(404);
            else return slice;

        }

        public ActionResult<SliceValue> Delete(string id)
        {
            int ids = Int32.Parse(id);
            SliceValue slice = db.SliceValues.FirstOrDefault(e => e.Id == ids);
            if (slice == null)
                return new StatusCodeResult(404);
            else
            {
                db.SliceValues.Remove(slice);
                db.SaveChanges();
                return slice;
            }

        }

        public ActionResult<SliceValue> Add(SliceValue slice)
        {
            if (slice == null) return new StatusCodeResult(400);
            else
            {
                db.SliceValues.Add(slice);
                db.SaveChanges();
                return slice;
            }
        }

        public ActionResult<SliceValue> Update(string id, SliceValue slice)
        {
            int ids = Int32.Parse(id);
            SliceValue oldslice = db.SliceValues.FirstOrDefault(e => e.Id == ids);
            if (oldslice == null)
                return new StatusCodeResult(404);
            else
            {
                oldslice.MaxValue = slice.MaxValue;
                oldslice.MinValue = slice.MinValue;
                oldslice.WaterPrice = slice.WaterPrice;
                oldslice.SanitationPrice = slice.SanitationPrice;
                oldslice.ValuesCondition = slice.ValuesCondition;
                oldslice.Notes = slice.Notes;
                db.SaveChanges();
                return oldslice;
            }



        }


    }
}
