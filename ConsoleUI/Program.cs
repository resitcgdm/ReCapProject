// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;
using Entities.Concrete;

//CarManagerTest();
////ikinci gösterim
//BrandManagerTest();

//UserManagerTest();

static void UserManagerTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Add(new User { FirstName = "Reşit", LastName = "Çiğdem", Email = "resitcgdm@gmail.com", Password = "1234567" });

    var result = userManager.GetAll();
    foreach (var user in result.Data)
    {
        Console.WriteLine(user.UserId + " / " + user.FirstName + " / " + user.LastName + " / " + user.Email + " / " + user.Password);
    }
}

static void BrandManagerTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    if (brandManager.GetAll().Success == true)
    {
        foreach (var bm in brandManager.GetAll().Data)

        {
            Console.WriteLine(bm.BrandId);
        }
    }

    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 08, 31, 18, 19, 22) });
    Console.WriteLine(result.Success);
    Console.WriteLine(result.Message);
}

static void CarManagerTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    //birinci gösterim
    var result = carManager.GetCarDetails();
    if (result.Success == true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName);
        }
    }
}
