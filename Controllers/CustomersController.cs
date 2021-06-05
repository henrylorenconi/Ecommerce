using ECommerce.Classes;
using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static ECommerce.Classes.UserHelper;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User")]
    public class CustomersController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Customers
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var customers = db.Customers.Where(c => c.CompanyId == user.CompanyId).Include(c => c.City).Include(c => c.Department);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(0), "CityId", "Name");

            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");

            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            var customer = new Customer
            {
                CompanyId = user.CompanyId
            };

            return View(customer);
        }

        // POST: Customers/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                UsersHelper.CreateUserASP(customer.UserName, "Customer");
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartamentsId), "CityId", "Name");

            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartamentsId), "CityId", "Name");

            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View(customer);
        }

        // POST: Customers/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(customer.DepartamentsId), "CityId", "Name");

            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            UsersHelper.DeleteUser(user.UserName, "Customer");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
