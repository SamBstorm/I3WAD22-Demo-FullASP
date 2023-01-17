﻿using Demo_ASP.Handlers;
using Demo_ASP.Models.ClientViewModels;
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
    public class ClientController : Controller
    {
        private readonly IClientRepository<Client, int> _service;

        public ClientController(IClientRepository<Client, int> service)
        {
            _service = service;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            IEnumerable<ClientListItem> model = _service.Get().Select(e => e.ToListItem());
            return View(model);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreateForm form)
        {
            if (!ModelState.IsValid)
            {
                form.pass = null;
                form.confirmPass = null;
                return View(form);
            }
            else
            {
                int id = _service.Insert(form.ToBLL());
                return RedirectToAction("Details", "Client", new { id = id });
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
