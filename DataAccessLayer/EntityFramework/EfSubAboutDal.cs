using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{

    public class EfSubAboutDal : GenericRepository<SubAbout>, ISubAboutDal
    {
        private readonly Context context;
        public EfSubAboutDal(Context context) : base(context)
        {
            this.context = context;
        }

        public SubAbout GetFirst()
        {
            return context.SubAbouts.First();
        }
    }
}
