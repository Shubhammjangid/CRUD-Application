using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUD.Controllers
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDetail()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            DataInfo dataInfo = new DataInfo();
            StudentInfo studentinfo = dataInfo.FetchOne(id);

            return View(studentinfo);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ProcessCreate(StudentInfo studentInfo)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.CreateorUpdate(studentInfo);
            return View("Details", studentInfo);
        }

        public ActionResult Edit(int id)
        {
            DataInfo dataInfo = new DataInfo();
            StudentInfo studentinfo = dataInfo.FetchOne(id);
            return View(studentinfo);
        }

        public ActionResult Delete(int id)
        {
            DataInfo dataInfo = new DataInfo();
            StudentInfo studentinfo = dataInfo.FetchOne(id);
            dataInfo.Delete(id);

            List<StudentInfo> student = dataInfo.FetchAll();
            return View(studentinfo);
        }
    }
}
