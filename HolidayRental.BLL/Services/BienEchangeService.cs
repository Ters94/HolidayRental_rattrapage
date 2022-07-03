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
   public class BienEchangeService : IBienEchangeRepository<BienEchangeBLL>
    {
        private readonly IBienEchangeRepository<BienEchange> _BienEchangeRepository;
        private readonly IMembreRepository<Membre> _MembreRepository;
        private readonly IPaysRepository<Pays> _PaysRepository;

    public BienEchangeService(IBienEchangeRepository<BienEchange> repository, IMembreRepository<Membre> membreRepository, IPaysRepository<Pays> paysRepository)
    {
        _BienEchangeRepository = repository;
        _MembreRepository = membreRepository;
        _PaysRepository = paysRepository;
    }

    public void Delete(int id)
    {
        _BienEchangeRepository.Delete(id);
    }

    public BienEchangeBLL Get(int id)
    {
            BienEchangeBLL result = _BienEchangeRepository.Get(id).ToBLL();
            result.Membre = _MembreRepository.Get(result.MembreId).ToBLL();
           // result.Pays = _PaysRepository.Get(result.PaysId).ToBLL();
            
        return result;
    }

        public IEnumerable<BienEchangeBLL> Get()
        {
            return _BienEchangeRepository.Get().Select(d =>
            {
                BienEchangeBLL result = d.ToBLL();
                result.Membre = _MembreRepository.Get(result.MembreId).ToBLL();
               // result.Pays = _PaysRepository.Get(result.PaysId).ToBLL();
                return result;
            });
        }
        public int Insert(BienEchangeBLL entity)
    {
        return _BienEchangeRepository.Insert(entity.ToDAL());
    }


   


 

    public void Update(int id, BienEchangeBLL entity)
    {
        _BienEchangeRepository.Update(id, entity.ToDAL());
    }
}
}
