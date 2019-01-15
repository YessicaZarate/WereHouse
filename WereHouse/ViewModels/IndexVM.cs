using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WereHouse.ViewModels
{
    public class IndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Item:")]
        public string Item { get; set; }

        [Display(Name = "Brand:")]
        public string Brand { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Quantity in Stock:")]
        public int Qty { get; set; } //In stock

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Cost:")]
        public double Cost { get; set; }

        [Display(Name = "Sale Price:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }
    }
}