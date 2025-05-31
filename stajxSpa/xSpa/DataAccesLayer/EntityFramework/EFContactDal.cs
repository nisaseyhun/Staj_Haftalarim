using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
        public EFContactDal(AppDbContext context) : base(context)
        {
        }
    }
}
