// See https://aka.ms/new-console-template for more information

using LinqÖrnek;

List<Category> categories = new List<Category>
{
    new Category{CategoryId=1,CategoryName="Bilgisayar" },
    new Category {CategoryId=2,CategoryName="Telefon"}
};


List<Product> products = new List<Product>
{new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",UnitPrice=10001},
 new Product{ProductId=2,CategoryId=2,ProductName="HP Laptop",UnitPrice=10000 },
new Product{ ProductId=3,CategoryId=2,ProductName="Asus Laptop",UnitPrice=3000}

};

//AnyTest(products);
//FindTest(products);
FindAllTest(products);

static void AnyTest(List<Product> products)
{
    var result = products.Any(p => p.ProductId == 1 && p.ProductName == "Acer Laptop"); //Any bool'dur true veya false döner.

    Console.WriteLine(result);
}


static void FindTest(List<Product> products)
{
    var result = products.Find(p => p.ProductId == 3); //aradığımız nesnenin kendisini verir.Ürünün detayına gitmek icin kullanılır.
    Console.WriteLine(result.ProductName);
}



static void FindAllTest(List<Product> products)
{
    var result = products.FindAll(p => p.ProductName.Contains("top"));   //içerisinde top olanları getirir.          

    Console.WriteLine(result.Count());


}                                                                           //şarta uyan bütün elemanları getirir.(where gibi)
                                                                            //where inumerable liste döner her yola çekebilirsin.
                                                                            //Findall ise direk liste döndürür.

AscDescTest(products);

static void AscDescTest(List<Product> products)
{    //Single Line Query
    var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}
//Linq 'in başka bir kullanımı
AnotherWayToUseLinq(products);

static void AnotherWayToUseLinq(List<Product> products)
{
    var result = from p in products
                 where p.UnitPrice > 6000 //bir şart daha koymak && ile mümkün
                 orderby p.UnitPrice descending, p.ProductName descending
                 select p;
    foreach (var p in result)
    {
        Console.WriteLine(p.ProductId);

    }
}

//Şimdi DTO ya geçelim yani Data Transfer Object

//ClassicLinqTest(products);

LinqExamples(categories, products);

static void LinqExamples(List<Category> categories, List<Product> products)
{
    static void ClassicLinqTest(List<Product> products)
    {
        var result = from p in products
                     where p.UnitPrice > 6000 //bir şart daha koymak && ile mümkün
                     orderby p.UnitPrice descending, p.ProductName descending
                     select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

        foreach (var p in result)
        {
            Console.WriteLine(p.ProductId);

        }
    }
    var result = from p in products
                 join c in categories
                 on p.CategoryId equals c.CategoryId
                 select new ProductDto
                 {
                     ProductId = p.ProductId,
                     CategoryName = c.CategoryName,
                     ProductName = p.ProductName,
                     UnitPrice = p.UnitPrice
                 };
    foreach (var dto in result)
    {
        Console.WriteLine("{0} ---->{1}", dto.ProductName, dto.CategoryName);
    }
}