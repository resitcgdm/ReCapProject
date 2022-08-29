using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SampleDatabase>, ICarDal
    {
     public List<CarDetailDto> GetCarDetails()
        {
            using (SampleDatabase context = new SampleDatabase())
            {
                var result = from c in context.Cars
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { CarName = c.CarName, BrandName = b.BrandName, ColorName = x.ColorName, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
            

        }
    }
}
