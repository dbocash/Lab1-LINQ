using System;
using System.Linq;
using System.Collections.Generic;

public class Program
    {
    public static void Main(string[] args)
    {
        Invoice[] invoices =
        {
            new Invoice( 83, "Electric sander", 7, 57.98M ),
            new Invoice( 24, "Power saw", 18, 99.99M ),
            new Invoice( 7, "Sledge hammer", 11, 21.5M ),
            new Invoice( 77, "Hammer", 76, 11.99M ),
            new Invoice( 39, "Lawn mower", 3, 79.5M ),
            new Invoice( 68, "Screwdriver", 106, 6.99M ),
            new Invoice( 56, "Jig saw", 21, 11M ),
            new Invoice( 3, "Wrench", 34, 7.5M ) };


        var byDescription =
            from item in invoices
            orderby item.PartDescription
            select item;

        Console.WriteLine("a) Sorted by description: \n");
        foreach (var item in byDescription)
            Console.WriteLine(item);

        var byPrice =
            from item in invoices
            orderby item.Price
            select item;

        Console.WriteLine("\nb) Sorted by Price: \n");
        foreach (var item in byPrice)
            Console.WriteLine(item);

        var decriptionAndQuantity =
            from item in invoices
            orderby item.Quantity
            select new
            {
                item.PartDescription,
                item.Quantity
            };
        Console.WriteLine("\nc) Description and quantity sort by quantity: \n");
        foreach (var item in decriptionAndQuantity)
            Console.WriteLine(item);

        var descriptionAndTotal = from item in invoices
                                  let total = item.Quantity * item.Price
                                  orderby total
                                  select new { item.PartDescription, InvoiceTotal = total };

        Console.WriteLine("\nd) Description and invoice total, sort by invoice total:\n");
        foreach (var item in descriptionAndTotal)
            Console.WriteLine(item);

        var totalBetween =
            from item in descriptionAndTotal
            where item.InvoiceTotal > 200M && item.InvoiceTotal < 500M
            select item;
        Console.WriteLine(string.Format(
            "\ne) Invoice totals between {0:C} and {1:C} :\n", 200, 500));
        foreach (var item in totalBetween)
            Console.WriteLine(item);
        

    }
}
