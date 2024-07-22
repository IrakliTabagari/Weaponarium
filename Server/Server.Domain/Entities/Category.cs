namespace Server.Domain.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    
    public Category ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
}