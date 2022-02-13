using Forms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{

    [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        testMvcEntities test = new testMvcEntities();

        public ActionResult About()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


        
        [HttpGet]
        public ActionResult Index(tbl_Product product)
        {
  

            var category = test.tbl_Category.ToList();
            if (category != null)
            {
                ViewBag.data = category;
            }
          /*ViewBag.Data = new SelectList(category,"CategoryName","CategoryId");*/
            return View("Index");

        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddProduct([Bind(Exclude ="ProductImage")]tbl_Product product)
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

          

            tbl_Product obj = new tbl_Product();
                obj.ProductId = product.ProductId;
                obj.ProductName = product.ProductName;
                obj.ProductImage = imageData;
                obj.ProductPrice = product.ProductPrice;
                obj.ProductDetails = product.ProductDetails;
                obj.CategoryId = product.CategoryId;

            var category = test.tbl_Category.ToList();
            if (category != null)
            {
                ViewBag.data = category; 
            }

            if(product.ProductId == 0) { 
            test.tbl_Product.Add(obj);
            test.SaveChanges();
            }
            else
            {
                test.Entry(obj).State = EntityState.Modified;
                test.SaveChanges();
            }
            ModelState.Clear();
            return View("Index"); ;

        }

        [Authorize(Roles = "Admin")]
        public ActionResult ProductList([Bind(Exclude = "ProductImage")]tbl_Product products)
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
            var product = test.tbl_Product.ToList();       
            return View(product);
            
        }

        public ActionResult RetriveImage(int Id)
        {
            byte[] cover = test.tbl_Product.Find(Id).ProductImage;
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
            var q = from temp in test.tbl_Product where temp.ProductId == Id select temp.ProductImage;
            byte[] cover = q.First();
            return cover;
        }



        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var del = test.tbl_Product.Where(x => x.ProductId == id).First();
            test.tbl_Product.Remove(del);
            test.SaveChanges();

            var list = test.tbl_Product.ToList();
            return View("ProductList",list);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}