using Business.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExperinceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperinceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void TAdd(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public Experience TGetById(int id)
        {
            return _experienceDal.GetByID(id);
        }

        public List<Experience> TGetList()
        {
           return _experienceDal.GetList();
        }

        public List<Experience> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience t)
        {
            _experienceDal.Update(t);
        }
    }
}
