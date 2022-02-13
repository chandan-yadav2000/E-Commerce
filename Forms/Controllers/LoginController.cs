using Forms.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Forms.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class LoginController : Controller
    {

        testMvcEntities dbContext = new testMvcEntities();

        [Authorize(Roles = "Admin,User")]
        public ActionResult Login()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult Dashboard([Bind(Exclude = "ProductImage")]tbl_Product product)
        {
            byte[] imageData = Convert.FromBase64String("ProductImage");
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["ProductImage"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }

            var product1 = dbContext.tbl_Product.ToList();
            return View(product1);

    
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult Index(Login login)
        {

            if (ModelState.IsValid) { 

             var admin = dbContext.tbl_Admin.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
            
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(login.Username,false);
                Session["User"] = admin.Username.ToString();
                Session["Password"] = admin.Password.ToString();
                return RedirectToAction("Index", "Home");
            }
            else {
            
                var user = dbContext.tbl_Mvc.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    Session["Username"] = user.Username.ToString();
                    Session["Password"] = user.Password.ToString();
                    return RedirectToAction("Dashboard", "Login");
                }
                else {
                    ViewBag.ErrorMessage = "Username not found or matched";
                }
            }
            }
            return View("Login");
        }

        public ActionResult Cart([Bind(Exclude = "ProductImage")]tbl_Product product)
        {

            byte[] imageData = Convert.FromBase64String("ProductImage");
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["ProductImage"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }
            if (Session["cart"] == null)
            {

                List<tbl_Product> product1 = new List<tbl_Product>();
                product1.Add(product);
                Session["cart"] = product1;
                ViewBag.Cart = product1.Count();
                Session["count"] = 1;
            }
            else
            {
                List<tbl_Product> product1 = (List<tbl_Product>)Session["cart"];
                product1.Add(product);
                Session["cart"] = product1;
                ViewBag.Cart = product1.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Dashboard", "Login");
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult CartView([Bind(Exclude = "ProductImage")]tbl_Product product)
        {
            byte[] imageData = Convert.FromBase64String("ProductImage");
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["ProductImage"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }

            return View((List<tbl_Product>)Session["cart"]);
        }



        [Authorize(Roles = "Admin,User")]
          public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult RetriveImage(int Id)
        {
            byte[] cover = dbContext.tbl_Product.Find(Id).ProductImage;
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        private byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in dbContext.tbl_Product where temp.ProductId == Id select temp.ProductImage;
            byte[] cover = q.First();
            return cover;
        }

        public ActionResult Remove(tbl_Product pro)
        {
            List<tbl_Product> li = (List<tbl_Product>)Session["cart"];
            li.RemoveAll(x=>pro.ProductName==pro.ProductName);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("CartView", "Login");

        }
       
    }

}