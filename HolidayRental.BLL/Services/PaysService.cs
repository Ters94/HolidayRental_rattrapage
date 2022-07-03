using Holiday.Rental.DAL;
using HolidayRental.BLL.Entities;
using HolidayRental.BLL.Handlers;
using HolidayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Services
{
    public class PaysService : IPaysRepository<PaysBLL>
    {
        
        private readonly IPaysRepository<Pays> _PaysRepository;

        public PaysService(IPaysRepository<Pays> repository)
        {
            _PaysRepository = repository;
        }

     
        public void Delete(int id)
        {
            _PaysRepository.Delete(id);
        }

        public PaysBLL Get(int id)
        {
            return _PaysRepository.Get(id).ToBLL();

        }
        public IEnumerable<PaysBLL> Get()
        {
            return _PaysRepository.Get().Select(p => p.ToBLL());

        }

        public int Insert(PaysBLL entity)
        {
            return _PaysRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, PaysBLL entity)
        {
            _PaysRepository.Update(id, entity.ToDAL());
        }
    }
}
