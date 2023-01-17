using Demo_ASP.Handlers;
using Demo_ASP.Models.SpectacleViewModels;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Controllers
{
    public class SpectacleController : Controller
    {
        private readonly ISpectacleRepository<Spectacle, int> _service;

        public SpectacleController(ISpectacleRepository<Spectacle, int> service)
        {
            _service = service;
        }

        // GET: SpectacleController
        public ActionResult Index()
        {
            IEnumerable<SpectacleListItem> model = _service.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: SpectacleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpectacleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpectacleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpectacleCreateForm form)
        {
            if (!ModelState.IsValid) return View(form);
            int id = _service.Insert(form.ToBLL());
            return RedirectToAction("Details", new { id = id });
        }

        // GET: SpectacleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpectacleController/Edit/5
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

        // GET: SpectacleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpectacleController/Delete/5
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
