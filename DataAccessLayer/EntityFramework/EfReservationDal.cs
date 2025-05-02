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
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        private readonly Context _context;
        public EfReservationDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Reservation> ReservationUserAndDestinationListByStatus(string status)
        {
            return _context.Reservations.Include("AppUser").Include("Destination").Where(x => x.Status == status).ToList();
        }

        public List<Reservation> ReservationUserAndDestinationList()
        {
            return _context.Reservations.Include("AppUser").Include("Destination").ToList();
        }
    }
}
