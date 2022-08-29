// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var cm in carManager.GetAll())
{
    Console.WriteLine(cm.Description);
}
BrandManager brandManager=new BrandManager(new EfBrandDal());
foreach (var bm in brandManager.GetAll())

{
    Console.WriteLine(bm.BrandId);
}
