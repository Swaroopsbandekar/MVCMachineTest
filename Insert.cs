using (var context = new MyDbContext())
{
    var newCategory = new Category
    {
        CategoryName = "Electronics"
    };
    context.Categories.Add(newCategory);
    context.SaveChanges();
}
using (var context = new MyDbContext())
{
    var product = context.Products.Find(1);
    product.CategoryId = 2; 
    context.SaveChanges();
}
using (var context = new MyDbContext())
{
    var category = context.Categories.Include(c => c.Products).Single(c => c.CategoryId == 1);
    context.Categories.Remove(category);
    context.SaveChanges();
}
using (var context = new MyDbContext())
{
    int pageSize = 10;
    int pageNumber = 9;
    var products = context.Products
        Include(p => p.Category)
        OrderBy(p => p.ProductId)
        Skip((pageNumber - 1) * pageSize)
        Take(pageSize)
        ToList();
    return products;
}