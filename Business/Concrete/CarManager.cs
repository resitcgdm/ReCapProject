using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll().Where(b => b.BrandId == id).OrderBy(b => b.DailyPrice > 0).ToList();
            return result;
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll().Where(c => c.ColorId == id).OrderBy(b => b.DailyPrice > 0).ToList();
        }
    }
}
