using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sample.BasicRestAspnetCore.EntitiesDomain.Base;

namespace Sample.BasicRestAspnetCore.EntitiesDomain
{
    [Table("book")]
    public class Book : BaseEntity
    {
       
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }


    }
}