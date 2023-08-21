// See https://aka.ms/new-console-template for more information
#region Out

using OtusHomework4;

using (AvitoContext db = new AvitoContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Users list:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.UserId}.{u.Username} - {u.Email}");
    }

    Console.WriteLine();
    Console.WriteLine();


    var categories = db.Categories.ToList();
    Console.WriteLine("Categories list:");
    foreach (Category category in categories)
    {
        Console.WriteLine($"{category.CategoryId}.{category.Name}");
    }


    Console.WriteLine();
    Console.WriteLine();


    var subcategories = db.Subcategories.ToList();
    Console.WriteLine("Subcategories list:");
    foreach (Subcategory subcategory in subcategories)
    {
        Console.WriteLine($"{subcategory.SubcategoryId}.{subcategory.Name}");
    }


    Console.WriteLine();
    Console.WriteLine();


    var advertisements = db.Advertisements.ToList();
    Console.WriteLine("Advertisements list:");
    foreach (Advertisement adv in advertisements)
    {
        Console.WriteLine($"{adv.AdId}.{adv.Title} : {adv.Description}");
    }


}

#endregion

Console.WriteLine();
Console.WriteLine();
