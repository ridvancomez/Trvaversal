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
    public class PictureManager : IPictureService
    {
        private readonly IPictureDal _pictureDal;

        public PictureManager(IPictureDal pictureDal)
        {
            _pictureDal = pictureDal;
        }

        public void Add(Picture entity)
        {
            _pictureDal.Add(entity);
        }

        public void Delete(Picture entity)
        {
            _pictureDal.Remove(entity);
        }

        public Picture GetById(int id)
        {
            return _pictureDal.GetById(id);
        }

        public List<Picture> GetList()
        {
            return _pictureDal.List();
        }

        public List<Picture> GetPictureWithDestinationList()
        {
            return _pictureDal.GetPictureWithDestinationList();
        }

        public void Update(Picture entity)
        {
            _pictureDal.Update(entity);
        }
    }
}
