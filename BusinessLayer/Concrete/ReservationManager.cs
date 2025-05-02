using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly Context _context;
        public ReservationManager(IReservationDal reservationDal, Context context)
        {
            _reservationDal = reservationDal;
            _context = context;
        }
        public void Add(Reservation entity)
        {
            _reservationDal.Add(entity);
        }

        public void Delete(Reservation entity)
        {
            _reservationDal.Remove(entity);
        }

        public Reservation GetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.List();
        }

        public int GetTotalPersonCount()
        {
            int personCount = _context.Reservations.Sum(x => x.PersonCount);
            return personCount;    
        }

        public List<Reservation> ReservationUserAndDestinationList()
        {
            return _reservationDal.ReservationUserAndDestinationList();
        }

        public List<Reservation> ReservationUserAndDestinationListByStatus(string status)
        {
            return _reservationDal.ReservationUserAndDestinationListByStatus(status);
        }

        public void Update(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
