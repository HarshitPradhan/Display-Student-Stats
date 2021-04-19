using Student_Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Stats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //  return View();
            query_student obj = new query_student();
            List<Student> stu = obj.getData();
            return View(stu);

        }

        public ActionResult About()
        {
            // ViewBag.Message = "Your application description page.";

            // return View();


            query_student s = new query_student();
            List<Student> s1 = s.getstudentwithlowestandhighestmarks();
            return View(s1);
        }

        public ActionResult Contact()
        {
            //   ViewBag.Message = "Your contact page.";

            //  return View();


            query_student s1 = new query_student();
            return View(s1);
        }
    }
}