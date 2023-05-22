using ConsoleApp2;

    var dbName = "sqldb1.db";
    if(File.Exists(dbName))
    {
        File.Delete(dbName);
    }
    await using var dbContext = new SqliteDbContext();
    await dbContext.Database.EnsureCreatedAsync();
    await dbContext.Products.AddRangeAsync(new Product[]
    {
        new Product(){Name = "Apple", Price = 10.99},
        new Product(){Name = "Bomba", Price = 50.99},
        new Product(){Name = "Banana", Price = 12.99},
    });
    await dbContext.SaveChangesAsync();

    Console.WriteLine("getting database data");
    dbContext.Products?.ToList().ForEach(p => Console.WriteLine(p.Name + " costs " + p.Price));
    Console.ReadLine();
