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
    public class CatagoryManager : ICatagoryService
    {
        ICatagoryDal _catagoryDal;

        public CatagoryManager(ICatagoryDal catagoryDal)
        {
            _catagoryDal = catagoryDal;
        }

        public void TAdd(Catagory t)
        {
            _catagoryDal.Insert(t);
        }

        public void TDelete(Catagory t)
        {
            _catagoryDal.Delete(t);
        }

        public Catagory TGetByID(int id)
        {
            return _catagoryDal.GetByID(id);
        }

        public List<Catagory> TGetList()
        {
            return _catagoryDal.GetList();
        }

        public void TUpdate(Catagory t)
        {
            _catagoryDal.Update(t);
        }
    }
}
