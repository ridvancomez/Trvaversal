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
    public class AboutImageManager : IAboutImageService
    {
        private readonly IAboutImageDal _aboutImageDal;
        public AboutImageManager(IAboutImageDal aboutImageDal)
        {
            _aboutImageDal = aboutImageDal;
        }
        public void Add(AboutImage entity)
        {
            _aboutImageDal.Add(entity);
        }

        public void Delete(AboutImage entity)
        {
            _aboutImageDal.Remove(entity);
        }

        public AboutImage GetById(int id)
        {
            return _aboutImageDal.GetById(id);
        }

        public List<AboutImage> GetList()
        {
            return _aboutImageDal.List();
        }

        public void Update(AboutImage entity)
        {
            _aboutImageDal.Update(entity);
        }
    }
}
