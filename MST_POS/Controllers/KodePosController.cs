using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MST_POS.Models;
using MST_POS.ModelClass;

namespace MST_POS.Controllers
{
    public class KodePosController : Controller
    {
        private KodePosClass kodePosClass;
        public KodePosController()
        {
            this.kodePosClass = new KodePosClass();
        }
        // GET: KodePos
        [HttpGet]
        public ActionResult KodePosIndex(string searchpropinsi = "", string searchkabupaten = "")
        {
            var kodePosModel = new List<KodePosModel>();
            kodePosModel = kodePosClass.GetIndexKodePos(searchpropinsi, searchkabupaten);
            return View(kodePosModel);
        }
        [HttpPost]
        public ActionResult KodePosIndex(FormCollection collect)
        {
            string searchpropinsi = collect["search-propinsi"];
            string searchkabupaten = collect["search-kabupaten"];
            return RedirectToAction("KodePosIndex", new { searchpropinsi = searchpropinsi, searchkabupaten = searchkabupaten });
        }
        [HttpGet]
        public JsonResult CreateKodePos()
        {
            var model = new KodePosModel();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateKodePos(KodePosModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    kodePosClass.CreateKodePos(model);
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Json(new { error = true });
                }
            }
            return Json(new { error = true });
        }
        [HttpGet]
        public JsonResult EditKodePos(int ID)
        {
            var model = kodePosClass.GetEditKodePosModel(ID);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditKodePos(KodePosModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    kodePosClass.EditKodePos(model);
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Json(new { error = true });
                }
            }
            return Json(new { error = true });
        }
        public ActionResult DeleteKodePos(int ID)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = kodePosClass.DeleteKodePos(ID);
                if (isDeleted) return RedirectToAction("KodePosIndex", new { data = "Delete" });
                return RedirectToAction("KodePosIndex");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("FailConfirmation", "Fail");
            }
        }
        public ActionResult DeleteFound(string data)
        {
            ViewBag.data = data;
            return View();
        }
    }
}