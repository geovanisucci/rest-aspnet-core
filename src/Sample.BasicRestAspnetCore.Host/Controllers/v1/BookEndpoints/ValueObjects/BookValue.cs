using System;
using System.Runtime.Serialization;

namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects
{
    [DataContract]
    public class BookValue
    {
        [DataMember(Order = 1, Name = "codigo")]
        public long Id { get; set; }
         [DataMember(Order = 2)]
        public string Title { get; set; }
         [DataMember(Order = 3)]
        public string Author { get; set; }
         [DataMember(Order = 5)]
        public decimal Price { get; set; }
         [DataMember(Order = 4)]
        public DateTime LaunchDate { get; set; }
    }
}