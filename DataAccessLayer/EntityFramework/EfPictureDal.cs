using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPictureDal : GenericRepository<Picture>, IPictureDal
    {
        private readonly Context _context;
        public EfPictureDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Picture> GetPictureWithDestinationList()
        {
            var list = _context.Pictures.Include("Destination").ToList();
            return list;
        }
    }
}
