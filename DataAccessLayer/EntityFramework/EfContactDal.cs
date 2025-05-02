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
    
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        private readonly Context context;
        public EfContactDal(Context context) : base(context)
        {
            this.context = context;
        }

        public Contact GetFirst()
        {
            return context.Contacts.First();
        }
    }
}
