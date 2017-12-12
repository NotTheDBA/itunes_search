using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSample.Models
{
    public class Result : IResult
    {

        public Int64 TrackId { get; set; }

        public string TrackName { get; set; }

        public string TrackViewUrl { get; set; }

        public string WrapperType { get; set; }

        public string Kind { get; set; }

        public string PrimaryGenreName { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public Int64 CollectionId { get; set; }

        public string ArtistName { get; set; }

        public string CollectionName { get; set; }

        public string CollectionCensoredName { get; set; }

        public string TrackCensoredName { get; set; }

        public string ArtistViewUrl { get; set; }

        public string CollectionViewUrl { get; set; }

        public string PreviewUrl { get; set; }

        public string ArtworkUrl60 { get; set; }

        public string ArtworkUrl100 { get; set; }

        public string CollectionPrice { get; set; }

        public string TrackPrice { get; set; }

        public string CollectionExplicitness { get; set; }

        public string TrackExplicitness { get; set; }

        public string DiscCount { get; set; }

        public string DiscNumber { get; set; }

        public string TrackCount { get; set; }

        public string TrackNumber { get; set; }

        public string TrackTimeMillis { get; set; }


    }

}
