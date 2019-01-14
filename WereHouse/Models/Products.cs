using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WereHouse.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        public string Item { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public int Qty { get; set; } //In stock

        public double Cost { get; set; }

        public double Price { get; set; }

        public string Country { get; set; } //From

        public string Provider { get; set; }

        public int Warranty { get; set; } //In weeks

        public DateTimeOffset? DateAd { get; set; } //Date when the items arrived

        public DateTimeOffset? DateCr { get; set; } //Creation date for the field

        public DateTimeOffset? DateUp { get; set; }//Updating date for the field
    }
}