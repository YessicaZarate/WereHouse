using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WereHouse.ViewModels
{
    public class DeleteVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Item:")]
        public string Item { get; set; }

        [Display(Name = "Brand:")]
        public string Brand { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Quantity in Stock:")]
        public int Qty { get; set; } //In stock

        [Display(Name = "Cost:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Cost { get; set; }

        [Display(Name = "Sale Price:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        [Display(Name = "Country of Origin:")]
        public string Country { get; set; } //From

        [Display(Name = "Provider:")]
        public string Provider { get; set; }

        [Display(Name = "Warranty (In Weeks):")]
        public int Warranty { get; set; } //In weeks

        [Display(Name = "Acquisition Date (DD/MM/YYYY):")]
        //[DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}")]
        public DateTimeOffset? DateAd { get; set; } //Date when the items arrived

        [Display(Name = "Date Created:")]
        //[DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}")]
        public DateTimeOffset? DateCr { get; set; } //Creation date for the field

        [Display(Name = "Date Updated:")]
        //[DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}")]
        public DateTimeOffset? DateUp { get; set; }//Updating date for the field
    }
}