using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using System.Net.Http.Headers;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.CCS;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService; //arabadan bağımsız sadece markalarımızı yönetmek istediğimiz için service cagırırız.


        public CarManager(ICarDal carDal, IBrandService brandService)
        {   

            _carDal = carDal;
            _brandService = brandService;
            
        }

        [ValidationAspect(typeof(CarValidator))] //attribute,autofac sayesinde.
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfNameOfCarCorrect(car.CarName), CheckIfCategoryLimitExceded());

            if(result!=null)
            {
                return result;
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);


            if (CheckIfCarCountOfBrandCorrect(car.BrandId).Success)
                
            {
              
            }

            else
            {
                return new ErrorResult();
            }

            if (CheckIfNameOfCarCorrect(car.CarName).Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult();
            }

        }
          
          

            //Loglama
            //cacheremove
            //performance
            //transaction
            //yetkilendirme(autorazthion)


       

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessDataResult<List<Car>>(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {   
            if(DateTime.Now.Hour==5)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            //Select Count(*) from Car Where BrandId=ne gönderdiysek => işlevi
          return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList());
        }

     

        public IResult Update(Car car)
        {   
          
            _carDal.Update(car);
            return new SuccessDataResult<List<Car>>(Messages.CarsUpdated);

        }

       public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId ==carId));
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        { //Aynı markadan en fazla 15 araba lislenmesi durumunda iş kodu olarak bunu yazmalıyız.
            var result = _carDal.GetAll(b => b.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            else
                return new SuccessResult();
        }
        //Aynı isimde araba eklenemez (daha önceden aynı isimle eklenmmiş gir araba)
        
        private IResult CheckIfNameOfCarCorrect(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            else
            {
                return new SuccessResult();
            }
            
        }
        private IResult CheckIfCategoryLimitExceded()  //eğer bu kuralı categorymanager'a yazarsak servis olmuş olur.
        {
            var result = _brandService.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);

            }
            else
            {
                return new SuccessResult();
            }
        }
    }
        
    }
