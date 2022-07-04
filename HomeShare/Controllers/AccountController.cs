using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HoliDayRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMembreRepository<MembreBLL>_MembreService;
        private readonly SessionManager _session;


        public AccountController(ILogger<AccountController> logger, IMembreRepository<MembreBLL> membreService, SessionManager session)
        {
            _logger = logger;
            _MembreService = membreService;
            this._session = session;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            if (_session.IsConnected) return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]

        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return View();
          
            _session.SetUser(form);
           
            int id = _MembreService.VerifPassword(form.Login, form.Password);
            if (id == -1) return View();
            _session.User = _MembreService.Get(id);
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //Exemple d'ajout de valeur pour une session permettant de spécifier que l'utilisateur est connecté
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
        //    return View();
        //}
    }
}
