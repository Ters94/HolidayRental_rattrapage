using Holiday.Rental.DAL;
using Holiday.Rental.DAL.Entities;
using HolidayRental.BLL.Entities;
using HolidayRental.BLL.Handlers;
using HolidayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Services
{
   public  class MembreService : IMembreRepository<MembreBLL>
    {
        private readonly IMembreRepository<Membre> _MembreRepository;
        private readonly IPaysRepository<Pays> _PaysRepository;

        public MembreService(IMembreRepository<Membre> repository, IPaysRepository<Pays> paysRepository)
        {
            _MembreRepository = repository;
            _PaysRepository = paysRepository;
        }

        

         
        public void Delete(int id)
        {
            _MembreRepository.Delete(id);
        }

        public MembreBLL Get(int id)
        {
            MembreBLL result = _MembreRepository.Get(id).ToBLL();
            result.Pays = _PaysRepository.Get(result.idPays).ToBLL();
            return result;
        }
        public IEnumerable<MembreBLL> Get()
        {
            return _MembreRepository.Get().Select(d =>
            {
                MembreBLL result = d.ToBLL();
                result.Pays = _PaysRepository.Get(result.idPays).ToBLL();
                return result;
            });
        }

        public int Insert(MembreBLL entity)
        {
            return _MembreRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, MembreBLL entity)
        {
            _MembreRepository.Update(id, entity.ToDAL());
        }
    }
}

