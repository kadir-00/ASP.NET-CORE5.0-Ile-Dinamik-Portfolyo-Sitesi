﻿using Business.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnoncoumentManager : IAnnoncoumentService
    {
        IAnnoncoumentDal _annoncoumentDal;

        public AnnoncoumentManager(IAnnoncoumentDal annoncoumentDal)
        {
            _annoncoumentDal = annoncoumentDal;
        }

        public void TAdd(Annoncoument t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Annoncoument t)
        {
            throw new NotImplementedException();
        }

        public Annoncoument TGetById(int id)
        {
            return _annoncoumentDal.GetByID(id);
        }

        public List<Annoncoument> TGetList()
        {
           return _annoncoumentDal.GetList();
        }

        public List<Annoncoument> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Annoncoument t)
        {
            throw new NotImplementedException();
        }
    }
}
