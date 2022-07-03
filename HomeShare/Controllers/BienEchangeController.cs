using HolidayRental.BLL.Entities;
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



        public BienEchangeController(IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IPaysRepository<PaysBLL> paysService)
        {
            _BienEchangeService = bienEchangeService;
            _PaysService = paysService;
           
        }

        // GET: BienEchangeController
        public ActionResult Index()
        {
            IEnumerable<BienListItem> model = _BienEchangeService.Get().Select(c => c.ToListItem());
            return View(model);
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
            return View();
        }

        // POST: BienEchangeController/Create
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
