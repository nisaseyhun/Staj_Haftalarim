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
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(AppDbContext context) : base(context)
        {
        }
    }
}
