using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{
    public class PaymentGatewayController : Controller
    {
        testMvcEntities dbContext = new testMvcEntities();
        // GET: PaymentGateway
        public ActionResult Index()
        {

            if (Session["cart"] != null)
            {
                var user = dbContext.tbl_Mvc.ToList();
                return View(user);

            }
            else
            {
                return RedirectToAction("Dashboard", "Login");
            }
        }

        [HttpPost]
        public ActionResult PaymentProcess(FormCollection form) {
            {
                try
                {
                    string FullName = string.Empty;
                    string MobileNo = string.Empty;
                    string Email = string.Empty;
                    string Address = string.Empty;
                    string surl = "https://localhost:44383/Return/Return";  
                    string furl = "https://localhost:44383/Return/Return";

                    string key = "ozBYv0";
                    
                    string salt = "1KubpzJDKALHIUkT8raOocVZJ7hkdKkj";

              
                    tbl_Product user = new tbl_Product();
                   
                 
                }
                catch { 
                }
            }            
            
            
            
            return View();
        }

    }
}