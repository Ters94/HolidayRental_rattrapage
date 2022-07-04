﻿using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class BienEchangeController : Controller
    {
        private readonly IBienEchangeRepository<BienEchangeBLL> _BienEchangeService;
        private readonly IPaysRepository<PaysBLL> _PaysService;
        private readonly SessionManager _session;



        public BienEchangeController(IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IPaysRepository<PaysBLL> paysService ,SessionManager session)
        {
            _BienEchangeService = bienEchangeService;
            _PaysService = paysService;
            _session = session;

        }

        // GET: BienEchangeController
        [Route("BienEchange/ListeBiens")]
        [Route("BienEchange")]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<BienListItem> model = _BienEchangeService.Get().Select(c => c.ToListItem());
                //model = model.Select(m => { m.Pays = _PaysService.Get(m.idPays).ToDetails(); return m; });
            return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        // GET: BienEchangeController/Details/5
        public ActionResult Details(int id)
        {

            BienDetails model = _BienEchangeService.Get(id).ToDetails();
            model.Pays = _PaysService.Get(model.idPays).ToDetails();
            return View(model);
        }

        // GET: BienEchangeController/Create
        public ActionResult Create()
        {
            if (!_session.IsConnected) return RedirectToAction("Login", "Account");
            BienEchangeCreate model = new BienEchangeCreate();
           // model.PaysList = _PaysService.Get().Select(s => s.ToDetails());
            model.idMembre = 1;
            return View(model);
        }

        // POST: BienEchangeController/Create
        [HttpPost]
       
        public ActionResult Create(BienEchangeCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                BienEchangeBLL result = new BienEchangeBLL(
                    0,
                    collection.titre,
                    collection.DescCourte,
                    collection.DescLong,
                    collection.NombrePerson,
                    collection.idPays,
                    collection.Ville,
                    collection.Rue,
                    collection.Numero,
                    collection.CodePostal,
                    collection.Photo,
                    collection.AssuranceObligatoire,
                    collection.Latitude,
                    collection.Longitude,
                    collection.idMembre
                );
                result.idBien = this._BienEchangeService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
               // collection.PaysList = _PaysService.Get().Select(s => s.ToDetails());
                return View(collection);
            }
        }

        // GET: BienEchangeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Edit/5
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

        // GET: BienEchangeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Delete/5
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
