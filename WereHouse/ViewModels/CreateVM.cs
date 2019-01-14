using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WereHouse.ViewModels
{
    public class CreateVM
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
        public double Cost { get; set; }

        [Display(Name = "Sale Price:")]
        public double Price { get; set; }

        [Display(Name = "Country of Origin:")]
        public string Country { get; set; } //From

        [Display(Name = "Provider:")]
        public string Provider { get; set; }

        [Display(Name = "Warranty (In Weeks):")]
        public int Warranty { get; set; } //In weeks

        [Display(Name = "Acquisition Date (DD/MM/YYYY):")]
        [DisplayFormat(DataFormatString ="DD/MM/YYYY")]
        public DateTimeOffset? DateAd { get; set; } //Date when the items arrived

        [DisplayFormat(DataFormatString = "DD/MM/YYYY")]
        public DateTimeOffset? DateCr { get; set; } //Creation date for the field

        [DisplayFormat(DataFormatString = "DD/MM/YYYY")]
        public DateTimeOffset? DateUp { get; set; }//Updating date for the field



    }
}