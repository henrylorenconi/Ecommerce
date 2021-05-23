using ECommerce.Classes;
using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        //Upload de imagens


        //Controle de List View em Cascata

        public JsonResult GetCities(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(m => m.DepartamentsId == departmentId);
            return Json(cities);
        }


        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Cities).Include(c => c.Departaments);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name");
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View();
        }

        // POST: Companies/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();

                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);

                    var response = FilesHelper.UploadPhoto(company.LogoFile, folder, file);
                    if (response == true)
                    {
                        pic = string.Format("{0}/{1}.jpg", folder, file);
                        company.Logo = pic;
                        db.Entry(company).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);

                    var response = FilesHelper.UploadPhoto(company.LogoFile, folder, file);
                    if (response == true)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        company.Logo = pic;
                    }

                }

                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", company.CityId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
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
