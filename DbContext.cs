Install-Package EntityFramework

public class MyDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public ICollection<Product> Products { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
using (var context = new MyDbContext())
{
    var products = context.Products.Include(p => p.Category).ToList();
    return products;
}