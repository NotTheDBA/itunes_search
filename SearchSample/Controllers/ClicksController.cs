using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchSample.Models;

namespace SearchSample.Controllers
{
    public class ClicksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //// GET: Clicks/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Click click = await db.Clicks.FindAsync(id);
        //    if (click == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(click);
        //}

        // GET: Clicks/Summary
        public async Task<ActionResult> Summary()
        {
 
            return View(await db.Clicks.GroupBy(x => new
            {
                x.TrackViewUrl,
                x.CollectionViewUrl,
                x.WrapperType,
                x.TrackName,
                x.TrackId,
                x.PrimaryGenreName,
                x.Kind,
                x.Currency,
                x.Country,
                x.CollectionName,
                x.CollectionId

            }).Select(c => new ClickSummary
            {
                CollectionId = c.Key.CollectionId,
                TrackViewUrl = c.Key.TrackViewUrl,
                CollectionViewUrl = c.Key.CollectionViewUrl,
                WrapperType = c.Key.WrapperType,
                TrackName = c.Key.TrackName,
                TrackId =  c.Key.TrackId,
                PrimaryGenreName = c.Key.PrimaryGenreName,
                Kind =  c.Key.Kind,
                Currency = c.Key.Currency,
                Country =  c.Key.Country,
                CollectionName =  c.Key.CollectionName,
                Clicks = c.Count()
            }
            ).OrderByDescending(c => c.Clicks).ToListAsync());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
