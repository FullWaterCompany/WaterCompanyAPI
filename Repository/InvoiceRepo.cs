
using global::WebApplication1.Models;
using global::WebApplication1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class InvoiceRepo : General<Invoice>, Iinvoice
    {
        waterComapnyContext db;
        Invoice Invoice;

        public InvoiceRepo(waterComapnyContext _db, Invoice _invoice)
        {
            db = _db;
            Invoice = _invoice;
        }

        public ActionResult<List<Invoice>> GetAll()
        {
            List<Invoice> invoices = db.Invoices.ToList();
            if (invoices == null)
                return new StatusCodeResult(404);
            else return invoices;
        }

        public ActionResult<Invoice> GetById(string id)
        {
            Invoice invoice = db.Invoices.FirstOrDefault(e => e.Id == id);
            if (invoice == null)
                return new StatusCodeResult(404);
            else return invoice;
        }

        public ActionResult<Invoice> Delete(string id)
        {
            Invoice invoice = db.Invoices.FirstOrDefault(e => e.Id == id);
            if (invoice == null)
                return new StatusCodeResult(404);
            else
            {
                db.Invoices.Remove(invoice);
                db.SaveChanges();
                return invoice;
            }
        }

        public ActionResult<Invoice> Add(Invoice invoice)
        {
            invoice.Id = "";
            invoice.SubscriptionNo = Invoice.SubscriptionNo.Trim();
            invoice.SubscriberNo = Invoice.SubscriberNo.Trim();
            invoice.PreviousConsumption = Invoice.PreviousConsumption;
            invoice.RealStateType = Invoice.RealStateType;
            invoice.IsThereSanitation = Invoice.IsThereSanitation;

            int? Unit_No = db.Subscriptions.FirstOrDefault(s => s.Id == invoice.SubscriptionNo).UnitNo;

            invoice.AmountConsumption = invoice.CurrentConsumption - invoice.PreviousConsumption;
            int? value = invoice.AmountConsumption;
            for (int x = 1; x <= 5 & invoice.AmountConsumption > 0; x++)
            {
                int? Minvalue = 15 * Unit_No;
                if (Minvalue < value)
                {
                    decimal? waterPrice = db.SliceValues.FirstOrDefault(s => s.Id == x).WaterPrice;

                    if (x != 5)
                    {
                        value = value - Minvalue;
                        int? rest = Minvalue;
                        invoice.ConsumptionValue += rest * waterPrice;
                    }
                    else
                    {
                        invoice.ConsumptionValue += value * waterPrice;
                    }
                }
                else
                {
                    decimal? waterPrice = db.SliceValues.SingleOrDefault(s => s.Id == x)?.WaterPrice;
                    invoice.ConsumptionValue += value * waterPrice;
                    break;
                }
            }
            if (invoice.IsThereSanitation == true)
                invoice.WastewaterConsumption = invoice.ConsumptionValue / 2;

            invoice.TotalInvoice = invoice.ConsumptionValue + invoice.WastewaterConsumption + invoice.ServiceFee;
            invoice.TaxValue = (decimal)((invoice.TotalInvoice * invoice.TaxRate) / 100);
            invoice.TotalBill = invoice.TotalInvoice + invoice.TaxValue;

            db.Invoices.Add(invoice);
            db.SaveChanges();

            return invoice;

        }
        public ActionResult<Invoice> Update(string id, Invoice invoice)
        {
            Invoice oldinvoice = db.Invoices.FirstOrDefault(e => e.Id == id);
            if (invoice == null)
                return new StatusCodeResult(404);
            else
            {
                oldinvoice.AmountConsumption = invoice.AmountConsumption;
                oldinvoice.ConsumptionValue = invoice.ConsumptionValue;
                oldinvoice.CurrentConsumption = invoice.CurrentConsumption;
                oldinvoice.WastewaterConsumption = invoice.WastewaterConsumption;
                oldinvoice.Date = invoice.Date;
                oldinvoice.ServiceFee = invoice.ServiceFee;
                oldinvoice.TaxRate = invoice.TaxRate;
                oldinvoice.SubscriptionNo = invoice.SubscriptionNo;
                oldinvoice.Notes = invoice.Notes;
                oldinvoice.From = invoice.From;
                oldinvoice.To = invoice.To;
                db.SaveChanges();
                return oldinvoice;
            }


        }
        public ActionResult<Invoice> GetInoviceData(string id)
        {
            Subscription subscription = db.Subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription != null)
            {
                Invoice.SubscriberNo = subscription.SubscriberCode;
                Invoice.SubscriptionNo = subscription.Id;
                Invoice.IsThereSanitation = subscription.IsThereSanitation;
                Invoice.PreviousConsumption = subscription.LastReading;
                Invoice.RealStateType = subscription.RealStateType;
                return Invoice;
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
    }

}
