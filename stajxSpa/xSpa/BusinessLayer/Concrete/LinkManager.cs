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
    public class LinkManager : ILinkService
    {
        ILinkDal _linkDal;

        public LinkManager(ILinkDal linkDal)
        {
            _linkDal = linkDal;
        }

        public void TAdd(Link t)
        {
            _linkDal.Insert(t);
        }

        public void TDelete(Link t)
        {
            _linkDal.Delete(t);
        }

        public Link TGetByID(int id)
        {
            return _linkDal.GetByID(id);
        }

        public List<Link> TGetList()
        {
            return _linkDal.GetList();
        }

        public void TUpdate(Link t)
        {
            _linkDal.Update(t);
        }
    }
}
