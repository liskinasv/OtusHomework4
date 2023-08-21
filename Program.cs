// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using OtusHomework4;



#region Output


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
        Console.WriteLine($"{subcategory.SubcategoryId}.{subcategory.Name}, номер категории: {subcategory.CategoryId}");
    }


    Console.WriteLine();
    Console.WriteLine();


    var advertisements = db.Advertisements.ToList();
    Console.WriteLine("Advertisements list:");
    foreach (Advertisement adv in advertisements)
    {
        Console.WriteLine($"{adv.AdId}.{adv.Title} : {adv.Description}, номер пользователя:{adv.UserId}, номер подкатегории{adv.SubcategoryId}");
    }


}

#endregion

Console.WriteLine();
Console.WriteLine();


while (true)
{

    Console.WriteLine("Введите номер таблицы для добавления записи:  1 - Users; 2 - Advertisements; 3 - Subcategory; 4 - Category; n - Выход");

    string numberTable = Console.ReadLine();


    switch (numberTable)
    {
        case "1":
            Console.WriteLine("Введите имя пользователя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите email пользователя:");
            string email = Console.ReadLine();
            InsertUser(name, email);
            break;
        case "2":
            Console.WriteLine("Введите заголовок объявления:");
            string title = Console.ReadLine();
            Console.WriteLine("Введите содержание объявления:");
            string description = Console.ReadLine();
            Console.WriteLine("Введите номер пользователя:");
            string userId = Console.ReadLine();
            Console.WriteLine("Введите номер подкатегории:");
            string subcategoryId = Console.ReadLine();
            InsertAdvertisement(title, description, Convert.ToInt32(userId), Convert.ToInt32(subcategoryId));
            break;
        case "3":
            Console.WriteLine("Введите подкатегорию:");
            string subcategory = Console.ReadLine();
            Console.WriteLine("Введите номер категории:");
            string categoryId = Console.ReadLine();
            InsertSubcategory(subcategory, Convert.ToInt32(categoryId));
            break;
        case "4":
            Console.WriteLine("Введите категорию:");
            string category = Console.ReadLine();
            InsertCategory(category);
            break;
        case "n":
            return;
        default:
            Console.WriteLine("Неправильно введен номер таблицы.");
            break;

    }

    Console.WriteLine();
    Console.WriteLine();


}



static void InsertUser(string name, string email)
{
    using (AvitoContext db = new AvitoContext())
    {
        try
        {
            int max = db.Users.Max(x => x.UserId);

            var user = new User
            {
                UserId = max + 1,
                Username = name,
                Email = email
            };
            db.Users.Add(user);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}

static void InsertCategory(string name)
{
    using (AvitoContext db = new AvitoContext())
    {
        try
        {
            int max = db.Categories.Max(x => x.CategoryId);

            var category = new Category
            {
                CategoryId = max + 1,
                Name = name
            };
            db.Categories.Add(category);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

static void InsertSubcategory(string name, int? categoryId)
{
    using (AvitoContext db = new AvitoContext())
    {
        try
        {
            int max = db.Subcategories.Max(x => x.SubcategoryId);

            var subcategory = new Subcategory
            {
                SubcategoryId = max + 1,
                Name = name,
                CategoryId = categoryId
            };
            db.Subcategories.Add(subcategory);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}


static void InsertAdvertisement(string title, string description, int? userId, int? subcategoryId)
{
    using (AvitoContext db = new AvitoContext())
    {
        try
        {

            int max = db.Advertisements.Max(x => x.AdId);

            var advertisement = new Advertisement
            {
                AdId = max + 1,
                Title = title,
                Description = description,
                UserId = userId,
                SubcategoryId = subcategoryId
            };
            db.Advertisements.Add(advertisement);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}


