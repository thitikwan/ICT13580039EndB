using System;
using SQLite;

namespace ICT13580039EndB.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}

        [NotNull]
        public string Category {get; set;}

        public string Brand {get;set;}

        public string Class {get;set;}
       
        public string Year {get;set;}

        public decimal Number {get;set;}

        public string Color {get;set;}

        public Boolean Status {get;set;}

        [NotNull]
        [MaxLength(100)]
        public string Description {get;set;}

        public decimal ProductPrice {get;set;}

        public string City {get;set;}

        [MaxLength (11)]
        public string TellPhone {get;set;}
    }
}
