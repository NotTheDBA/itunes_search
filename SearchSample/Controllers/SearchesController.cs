using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SearchSample.Models;

namespace SearchSample.Controllers
{
    public class SearchesController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
         
        // POST: Searches/Jump
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Jump([Bind(Include = "TrackId, TrackName, TrackViewUrl, WrapperType, Kind, PrimaryGenreName, Country, Currency, CollectionId, ArtistName, CollectionName, CollectionCensoredName, TrackCensoredName, ArtistViewUrl, CollectionViewUrl, PreviewUrl, ArtworkUrl60, ArtworkUrl100, CollectionPrice, TrackPrice, CollectionExplicitness, TrackExplicitness, DiscCount, DiscNumber, TrackCount, TrackNumber, TrackTimeMillis")] Result result)
        {
            Click click = new Click {
                ArtistName = result.ArtistName,
                CollectionName = result.CollectionName,
                CollectionCensoredName = result.CollectionCensoredName,
                TrackCensoredName = result.TrackCensoredName,
                ArtistViewUrl = result.ArtistViewUrl,
                PreviewUrl = result.PreviewUrl,
                ArtworkUrl60 = result.ArtworkUrl60,
                ArtworkUrl100 = result.ArtworkUrl100,
                CollectionPrice = result.CollectionPrice,
                TrackPrice = result.TrackPrice,
                CollectionExplicitness = result.CollectionExplicitness,
                TrackExplicitness = result.TrackExplicitness,
                DiscCount = result.DiscCount,
                DiscNumber = result.DiscNumber,
                TrackCount = result.TrackCount,
                TrackNumber = result.TrackNumber,
                TrackTimeMillis = result.TrackTimeMillis,
                WrapperType = result.WrapperType,
                Kind = result.Kind,
                CollectionId = result.CollectionId,
                TrackId = result.TrackId,
                TrackViewUrl = result.TrackViewUrl,
                CollectionViewUrl = result.CollectionViewUrl,
                TrackName = result.TrackName,
                PrimaryGenreName = result.PrimaryGenreName,
                Country = result.Country,
                Currency = result.Currency
            };
            db.Clicks.Add(click);
            await db.SaveChangesAsync();
            if (click.TrackViewUrl == null)
            {

                return Redirect(click.CollectionViewUrl);

            }
            else
            {
                return Redirect(click.TrackViewUrl);

            }

        }
    
        // GET: Searches/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Searches/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search([Bind(Include = "Id,Term")] Search search)
        {
            if (ModelState.IsValid)
            {

                db.Searches.Add(search); 
                await db.SaveChangesAsync();

                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("term", search.Term);

                SearchResults searchResults;
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(GetApiUrl("search", query));
                    searchResults = JsonConvert.DeserializeObject<SearchResults>(json);
                }

                TempData["searchResults"] = searchResults;

                return RedirectToAction("Results", searchResults);
            }

            return View(search);
        }

        // GET: Results
        public async Task<ActionResult> Results()
        {
            SearchResults searchResults = (SearchResults)TempData["searchResults"]; 
            return View(searchResults);
        }

        private static string GetApiUrl(string parmType, System.Collections.Specialized.NameValueCollection query)
        {
            const string rootUrl = "https://itunes.apple.com/";
            const int resultLimit = 100;
            //const string countryCode = "us";

            query.Add("limit", resultLimit.ToString());
            //query.Add("country", countryCode);
            return string.Format(rootUrl + parmType + "?{0}", query.ToString());
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
