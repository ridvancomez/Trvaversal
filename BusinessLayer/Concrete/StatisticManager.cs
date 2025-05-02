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
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;
        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public void Add(Statistic entity)
        {
            _statisticDal.Add(entity);
        }

        public void Delete(Statistic entity)
        {
            _statisticDal.Remove(entity);
        }

        public Statistic GetById(int id)
        {
            return _statisticDal.GetById(id);
        }

        public List<Statistic> GetList()
        {
            return _statisticDal.List();
        }

        public void Update(Statistic entity)
        {
            _statisticDal.Update(entity);
        }
    }
}
