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
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void Add(SubAbout entity)
        {
            _subAboutDal.Add(entity);
        }

        public void Delete(SubAbout entity)
        {
            _subAboutDal.Remove(entity);
        }

        public SubAbout GetById(int id)
        {
            return _subAboutDal.GetById(id);
        }

        public SubAbout GetFirst()
        {
            return _subAboutDal.GetFirst();
        }

        public List<SubAbout> GetList()
        {
            return _subAboutDal.List();
        }

        public void Update(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }
    }
}
