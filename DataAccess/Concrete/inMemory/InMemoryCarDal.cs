using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.inMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;            //cotr ile constructor oluşturuyoruz.
                                    //Aslında her class oluşturduğumuzda program otomatik olarak constructor oluşturur.
                                    //Default olarak Değer tipi 0 Referans tipi null olan bir constructor oluşur.
                                    //nesne yönelimli programlama kavramı içerisinde bulunan sınıf yapılarının
                                    //nesne olarak tanımlanmasında
                                    //alt yapıyı hazırlayan, kurucu rolü üstlenen,
                                    //sınıf ismi ile aynı isime sahip olan, geriye değer döndürmeyen fonksiyon türleridir.

        //Yani Kısaca İşlemlerin inşa sürecinde yapılacak aşamaları
        //belirttiğimiz için değişikliklerimizi ileride olası durumda hızlı ve esnek bir şekilde değiştirmemize olanak sağlar.


        public InMemoryCarDal()
        {
            _cars = new List<Car> {
               new Car { CarId =1,BrandId=1,ColorId=1,ModelYear=2003,DailyPrice=300,Description="Ford Focus"},
               new Car {CarId=2,BrandId=1,ColorId=7,ModelYear=2006,DailyPrice=500,Description="Ford Fiesta"},
               new Car { CarId =3,BrandId=2,ColorId=4,ModelYear=2008,DailyPrice=600,Description="Hyundai" },
               new Car {CarId=4,BrandId=3,ColorId=7,ModelYear=2013,DailyPrice=900,Description="Wolsvogen"},
               new Car {CarId=5,BrandId=4,ColorId=5,ModelYear=2021,DailyPrice=1500,Description="Bmw"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {                                                                       //LINQ bizim için foreach döngüsünü yapıyor.        
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId); //parametre olarak girilecek car id miz ile
                                                                                //burada oluşturulan car id uyuşursa sil diyoruz.
            _cars.Remove(carToDelete);

       }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
                  
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.Description=car.Description;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            
        }
    }
}
