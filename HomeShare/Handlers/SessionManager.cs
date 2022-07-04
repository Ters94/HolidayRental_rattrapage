﻿using HolidayRental.BLL.Entities;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoliDayRental.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
        public bool IsConnected { get { return _session.GetString(nameof(User)) != null; } }

        public MembreBLL User
        {
            set
            {
                _session.SetString(nameof(User), JsonSerializer.Serialize(value));
            }
            get
            {
                return JsonSerializer.Deserialize<MembreBLL>(_session.Get(nameof(User)));
            }
        }

        public void SetUser(LoginForm form)
        {
            _session.SetString("user", form.Login);
        }

        public void ForgetUser()
        {
            _session.Remove("user");
        }

    }
}
