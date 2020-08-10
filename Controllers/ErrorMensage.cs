using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemCC.Controllers
{
    public class ErrorMensage : Controller
    {
        // GET: ErrorMensage
        public ActionResult Index()
        {
            return View();
        }

        // GET: ErrorMensage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ErrorMensage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ErrorMensage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ErrorMensage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ErrorMensage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ErrorMensage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ErrorMensage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
