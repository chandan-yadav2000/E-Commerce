using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forms.Models
{

 
    public class Register
    {
        public int Id { get; set; }


        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "First Name is required")]
        public string Name { get; set; }


        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Display(Name = "Gender:")]
        [Required(ErrorMessage = "Please Select a gender")]
        public string Gender { get; set; }


        [Display(Name = "Enter Your Age:")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }


        [Display(Name = "Mobile No:")]
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [MinLength(10, ErrorMessage = "Minimum 10 character is required")]
        public int MobileNo { get; set; }


        [Display(Name = "Email Id:")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Display(Name = "Username:")]
        [Required(ErrorMessage = "Username is Compolusory")]
        public string Username { get; set; }


        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="Minimum 8 character is required")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword:")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
       
        public string cofirmPassword { get; set; }
    }
}