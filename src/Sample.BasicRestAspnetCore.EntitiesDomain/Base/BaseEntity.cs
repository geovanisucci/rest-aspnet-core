using System.Runtime.Serialization;

namespace Sample.BasicRestAspnetCore.EntitiesDomain.Base
{
    //Common table structure 
    [DataContract]
    public class BaseEntity
    {
         public long Id { get; set; }
    }
}