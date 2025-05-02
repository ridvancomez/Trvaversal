using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLaterManager : INewsLaterService
    {
        private readonly INewsLaterDal _newsLaterDal;
        public NewsLaterManager(INewsLaterDal newsLaterDal)
        {
            _newsLaterDal = newsLaterDal;
        }
        public void Add(NewsLetter entity)
        {
            _newsLaterDal.Add(entity);
        }
        public void Delete(NewsLetter entity)
        {
            _newsLaterDal.Remove(entity);
        }
        public NewsLetter GetById(int id)
        {
            return _newsLaterDal.GetById(id);
        }
        public List<NewsLetter> GetList()
        {
            return _newsLaterDal.List();
        }
        public void Update(NewsLetter entity)
        {
            _newsLaterDal.Update(entity);
        }
    }
}
