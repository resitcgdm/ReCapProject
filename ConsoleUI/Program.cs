// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;

CarManager carManager = new CarManager(new EfCarDal());
//birinci gösterim
var result = carManager.GetCarDetails();
if (result.Success==true)
{
    foreach (var car in result.Data)
    {
        Console.WriteLine(car.CarName);
    }
}
//ikinci gösterim
BrandManager brandManager=new BrandManager(new EfBrandDal());
if(brandManager.GetAll().Success==true) {
foreach (var bm in brandManager.GetAll().Data)

{
    Console.WriteLine(bm.BrandId);
}
}
