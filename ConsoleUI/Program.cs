// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete.inMemory;

CarManager carManager = new CarManager(new InMemoryCarDal());
foreach (var cm in carManager.GetAll())
{
    Console.WriteLine(cm.Description);
}
