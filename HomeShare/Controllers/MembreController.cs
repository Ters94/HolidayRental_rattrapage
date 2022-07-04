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
    public class MembreController : Controller
    {
        private readonly IMembreRepository<MembreBLL> _MembreService;
        private readonly IPaysRepository<PaysBLL> _PaysService;


        public MembreController(IMembreRepository<MembreBLL> MembreService, IPaysRepository<PaysBLL> paysService)
        {
            _MembreService = MembreService;
            _PaysService = paysService;

        }
        public ActionResult Index()
        {
            return RedirectToAction("ListeMembre");
        }
        // GET: MembreController
        public IActionResult ListeMembre()
        {
            try
            {
                IEnumerable<MembreListItem> model = _MembreService.Get().Select(c => c.ToListItem());
                model = model.Select(m => { m.Pays = _PaysService.Get((int)m.idPays).ToDetails(); return m; });
                return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        // GET: MembreController/Details/5
        public ActionResult Details(int id)
        {
            MembreDetails model = _MembreService.Get(id).ToDetails();
            model.Pays = _PaysService.Get((int)model.idPays).ToDetails();
            return View(model);
        }

        // GET: MembreController/Create
        public ActionResult Create()
        {
            MembreCreate model = new MembreCreate();
             model.PaysList = _PaysService.Get().Select(s => s.ToDetails());
            return View(model);
        }

        // POST: MembreController/Create
        [HttpPost]
        public IActionResult Create(MembreCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.VerifCondition) throw new ArgumentException("Merci d'accepter les conditions");
                MembreBLL result = new MembreBLL(
                    0,
                    collection.Nom,
                    collection.Prenom,
                    collection.Email,
                    collection.idPays,
                    collection.Telephone,
                    collection.Login,
                    collection.Password
                );
                result.idMembre = this._MembreService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.PaysList = _PaysService.Get().Select(s => s.ToDetails());
                return View(collection);
            }
        }

        // GET: MembreController/Edit/5
        public ActionResult Edit(int id)
        {
            MembreEdit model = this._MembreService.Get(id).ToEdit();
            model.PaysList = _PaysService.Get().Select(s => s.ToDetails());

            return View(model);
        }

        // POST: MembreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MembreEdit collection)
        {
            MembreBLL result = this._MembreService.Get(id);
            try
            {
                if (result is null) throw new Exception("Pas d'étudiant avec cet identifiant");
                if (!(ModelState.IsValid)) throw new Exception();
                //Les tests de validations étant correct, on met à jour l'étudiant 'result' avant l'envoi dans la DB
                result.Nom = collection.Nom;
                result.Prenom = collection.Prenom;
                result.Email = collection.Email;
                result.idPays = collection.idPays;
                result.Telephone = collection.Telephone;
                result.Login = collection.Login;
                if (collection.Password is not null) result.Password = collection.Password;
                this._MembreService.Update(id, result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                if (result is null) return RedirectToAction(nameof(Index));
                collection.PaysList = _PaysService.Get().Select(s => s.ToDetails());
                return View(result.ToEdit());
            }
        }

        // GET: MembreController/Delete/5
        public ActionResult Delete(int id)
        {
            MembreDelete model = this._MembreService.Get(id).ToDelete();
            return View(model);
        }

        // POST: MembreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MembreDelete collection)
        {
            MembreBLL result = this._MembreService.Get(id);
            try
            {
                if (result is null) throw new Exception("Pas d'étudiant avec cet identifiant.");
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.Validate) throw new Exception("Action non validée...");
                this._MembreService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
