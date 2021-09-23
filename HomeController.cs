using SearchFunctionalityWithJquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchFunctionalityWithJquery.Controllers
{
    public class HomeController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();
        public ActionResult Index()
        {
            return View(db.StudentInfoes.ToList());
        }

        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<StudentInfo> StuList = new List<StudentInfo>();
            if (SearchBy == "ID")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    StuList = db.StudentInfoes.Where(x => x.StuId == Id || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                StuList = db.StudentInfoes.Where(x => x.StuName.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}