using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forms.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        
        [Display(Name ="Product Image:")]
        [Required(ErrorMessage ="You Cannot leave the field empty")]
        public byte[] ProductImage { get; set; }

        [Display(Name = "Product Name:")]
        [Required(ErrorMessage = "You Cannot leave the field empty")]
        public string ProductName { get; set; }


        [Display(Name = "Product Price:")]
        [Required(ErrorMessage = "You Cannot leave the field empty")]
        public string ProductPrice { get; set; }

        [Display(Name = "Product Details:")]
        [Required(ErrorMessage = "You Cannot leave the field empty")]
        public string ProductDetails { get; set; }

        [Display(Name = "Category:")]
        [Required(ErrorMessage = "You Cannot leave the field empty")]
        public Nullable<int> CategoryId { get; set; }

    }
}