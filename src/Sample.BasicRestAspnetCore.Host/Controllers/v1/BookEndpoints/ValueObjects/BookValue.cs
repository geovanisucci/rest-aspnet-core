using System;

namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects
{
    public class BookValue
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}