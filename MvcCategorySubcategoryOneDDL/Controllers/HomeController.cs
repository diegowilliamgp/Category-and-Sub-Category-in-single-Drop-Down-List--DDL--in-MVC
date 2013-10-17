using MvcCategorySubcategoryOneDDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCategorySubcategoryOneDDL.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.StateDistrictList = new SelectList(getStateDistrictList(), "Id", "Column1");
            return View();
        }

        [HttpPost]
        public ActionResult Index(StateDistrictViewModel model)
        {
            int selectedDistrictId = Convert.ToInt32(model.SelectedStateDistrict);
            //query to get District
            var districtname = db.Districts.Where(x => x.Id == selectedDistrictId).Select(x => x.DistrictName).FirstOrDefault();
            //query to get State
            var statename = db.Districts.Where(x => x.Id == selectedDistrictId).Select(x => x.State.StateName).FirstOrDefault();

            ViewBag.StateDistrictList = new SelectList(getStateDistrictList(), "Id", "Column1");
            ViewBag.Message = "You have selected State = " + statename + " and District = " + districtname;
            return View();
        }

        private System.Collections.IEnumerable getStateDistrictList()
        {
            //SELECT ' -> ' + Districts.DistrictName, Districts.Id, Districts.StateId FROM Districts
            //UNION SELECT States.StateName, -1 , States.Id FROM States ORDER BY Districts.StateId,Districts.Id

            return (
                        from Districts in db.Districts
                        select new
                        {
                            Column1 = (" -> " + Districts.DistrictName),
                            Id = Districts.Id,
                            StateId = Districts.StateId
                        }
                    ).Union
                    (
                        from States in db.States
                        select new
                        {
                            Column1 = States.StateName,
                            Id = (-1),
                            StateId = States.Id
                        }
                    ).OrderBy(p => p.StateId).ThenBy(p => p.Id).ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}