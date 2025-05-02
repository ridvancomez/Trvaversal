using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;
        private readonly Context _context;

        public DestinationManager(IDestinationDal destinationDal, Context context)
        {
            _destinationDal = destinationDal;
            _context = context;
        }

        public void Add(Destination entity)
        {
            _destinationDal.Add(entity);
        }

        public void Delete(Destination entity)
        {
            _destinationDal.Remove(entity);
        }

        public Destination GetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public List<SelectListItem> GetDestinationList()
        {
            List<SelectListItem> values = (from x in _destinationDal.List()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           }).ToList();
            return values;
        }

        public List<DestinationPersonCountDTO> GetDestinationUsersCount()
        {
            var list = (from item in _context.Destinations
                        join item2 in _context.Reservations on item.Id equals item2.DestinationId
                        group item2 by item.City into g
                        select new DestinationPersonCountDTO
                        {
                            City = g.Key,
                            SubTitle = g.First().Destination.SubTitle, // SubTitle kısmında hata veriyor. Bu kısım hakkında bilgi verir misiniz? DTO katmanında SubTitle var.
                            PersonCount = g.Sum(x => x.PersonCount)

                        }

            ).ToList();

            return list;
        }

        public List<Destination> GetList()
        {
            return _destinationDal.List();
        }

        public void Update(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}
