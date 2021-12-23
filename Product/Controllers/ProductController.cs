using Product.Models;
using Product.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.GetAll();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductStructure p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Add(p);
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult AddToCart (int id)
        {
            Database db = new Database();
            ProductStructure p = db.Products.AddToCart(id);

            Session["Id"] = p.Id;
            Session["Name"] = p.Name;
            Session["Price"] = p.Price;
            Session["Quantity"] = p.Quantity;
            Session["Description"] = p.Description;

            if (p!=null)
            {
                List<ProductStructure> products = null;
                if (Session["Cart"] == null)
                {
                    products = new List<ProductStructure>();
                }
                else
                {
                    string json2 = Session["Cart"].ToString();
                    products = new JavaScriptSerializer().Deserialize<List<ProductStructure>>(json2);
                }
                products.Add(p);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = json;
            }
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            string json = Session["Cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductStructure>>(json);
            return View(products);
        }

        [HttpGet]
        public ActionResult Orders()
        {
            Database db = new Database();
            return View();
        }


    }
}