using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{
    public class RegisterController : Controller
    {


        testMvcEntities testDb = new testMvcEntities();


        // GET: Register
        public ActionResult Register()
        {

            return View();


        }

        [HttpPost]
        public ActionResult AddDetails(tbl_Mvc model)
        {

            if (ModelState.IsValid)
            {
                tbl_Mvc obj = new tbl_Mvc();
                obj.UserId = model.UserId;
                obj.Name = model.Name;
                obj.LastName = model.LastName;
                obj.Age = model.Age;
                obj.Gender = model.Gender;
                obj.Address = model.Address;
                obj.MobileNo = model.MobileNo;
                obj.Email = model.Email;
                obj.Username = model.Username;
                obj.Password = model.Password;

                testDb.tbl_Mvc.Add(obj);
                testDb.SaveChanges();
            }
            /* else
             {
                 testDb.Entry(obj).State = EntityState.Modified;
                 testDb.SaveChanges();
             }*/
            ModelState.Clear();
            return RedirectToAction("Login","Login");

        }


        public new ActionResult Profile() {

            var profile = testDb.tbl_Mvc.ToList();
            return View(profile);

        }

    }
} 

