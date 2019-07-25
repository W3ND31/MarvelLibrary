using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public string SeriesName { get; set; }
        public DateTime OnSaleDate { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }

        public Comic()
        {
        }

        public Comic(int id, string title, string format, int pageCount, string seriesName, DateTime onSaleDate, string thumbnail,string description)
        {
            Id = id;
            Title = title;
            Format = format;
            PageCount = pageCount;
            SeriesName = seriesName;
            OnSaleDate = onSaleDate;
            Thumbnail = thumbnail;
            Description = description;
        }
    }
}
