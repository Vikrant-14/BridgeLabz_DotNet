using ContosoPizza.Data;
using ContosoPizza.Models;

using ContosoPizzaContext _context = new ContosoPizzaContext();

// ADD
//Product veggieSpecial = new Product()
//{
//    Name = "Veggie Special Pizza",
//    Price = 349.99M
//};
//_context.Products.Add(veggieSpecial);
//_context.SaveChanges();

//Product chickenTikka = new Product()
//{
//    Name = "Chicken Tikka Pizza",
//    Price = 499.99M
//};
//_context.Add(chickenTikka);
//_context.SaveChanges();


//Update
var veggieSpecial = _context.Products.Where(p => p.Name == "Veggie Special Pizza").FirstOrDefault();
if(veggieSpecial is Product)
{
    veggieSpecial.Price = 339.99M;
}
_context.SaveChanges();

// Delete
if(veggieSpecial is Product)
{
    _context.Remove(veggieSpecial);
}
_context.SaveChanges();

// SELECT
var products = from product in _context.Products
              // where product.Price > 350
              orderby product.Name
              select product;

foreach (Product p in products)
{
    Console.WriteLine($"Product ID  : {p.Id}");
    Console.WriteLine($"Product Name  : {p.Name}");
    Console.WriteLine($"Product Price : {p.Price}");
    Console.WriteLine(new String('-', 20));
}



