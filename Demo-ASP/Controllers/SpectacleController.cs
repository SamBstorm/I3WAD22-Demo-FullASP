﻿using Demo_ASP.Handlers;
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
        private readonly ISpectacleRepository<Spectacle, int> _serviceSpectacle;

        public SpectacleController(ISpectacleRepository<Spectacle, int> service, IRepresentationRepository<Representation, int> serviceRepresentation)
        {
            _serviceSpectacle = service;
        }

        // GET: SpectacleController
        public ActionResult Index()
        {
            IEnumerable<SpectacleListItem> model = _serviceSpectacle.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: SpectacleController/Details/5
        public ActionResult Details(int id)
        {
            SpectacleDetails model = _serviceSpectacle.Get(id).ToDetails();
            if (model is null) {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
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
            int id = _serviceSpectacle.Insert(form.ToBLL());
            return RedirectToAction("Details", new { id = id });
        }

        // GET: SpectacleController/Edit/5
        public ActionResult Edit(int id)
        {
            SpectacleEditForm model = _serviceSpectacle.Get(id).ToEdit();
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: SpectacleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpectacleEditForm form)
        {
            if (!ModelState.IsValid) return View(form);
            if (!_serviceSpectacle.Update(id, form.ToBLL()))
            {
                ViewBag.Error = "Erreur lors de la mise à jour... Réessayez";
                return View(form);
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: SpectacleController/Delete/5
        public ActionResult Delete(int id)
        {
            SpectacleDelete model = _serviceSpectacle.Get(id).ToDelete();
            if (model is null)
            {
                TempData["Error"] = "Spectacle inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: SpectacleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SpectacleDelete form)
        {
            if (!_serviceSpectacle.Delete(id))
            {
                TempData["Error"] = "Erreur de suppression...";
            }
            return RedirectToAction("Index");
        }
    }
}
