﻿using HolidayRental.BLL.Entities;
using HolidayRental.Common.Repositories;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBienEchangeRepository<BienEchangeBLL> _BienEchangeService;
        private readonly IPaysRepository<PaysBLL> _PaysService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext  ,IBienEchangeRepository<BienEchangeBLL> bienEchangeService, IPaysRepository<PaysBLL> paysService)
        {
            _logger = logger; 
            _httpContext=httpContext;
            _BienEchangeService = bienEchangeService;
            _PaysService = paysService;
        }

        public IActionResult Index()
        {
            //_httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

           home model = new home();

            model.BiensEchanges = _BienEchangeService.Get().Select(c => c.ToListItem());
            //model.BiensEchanges = model.BiensEchanges.Select(m => { m.idPays = _PaysService.Get(m.idPays).ToDetails(); return m; });
            return View(model);
        }

        public IActionResult conditions()
        {
            return View();
        }
    }
}
