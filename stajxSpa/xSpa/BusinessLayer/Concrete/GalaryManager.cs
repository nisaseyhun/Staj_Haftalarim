using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GalaryManager : IGalaryService
    {
        IGalaryDal _galaryDal;

        public GalaryManager(IGalaryDal galaryDal)
        {
            _galaryDal = galaryDal;
        }

        public void TAdd(Galary t)
        {
            _galaryDal.Insert(t);
        }

        public void TDelete(Galary t)
        {
            _galaryDal.Delete(t);
        }

        public Galary TGetByID(int id)
        {
            return _galaryDal.GetByID(id);
        }

        public List<Galary> TGetList()
        {
            return _galaryDal.GetList();
        }

        public void TUpdate(Galary t)
        {
            throw new NotImplementedException();
        }
    }
}
