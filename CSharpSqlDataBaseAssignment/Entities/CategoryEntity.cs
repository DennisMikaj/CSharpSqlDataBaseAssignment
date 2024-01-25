using System.ComponentModel.DataAnnotations;

namespace CSharpSqlDataBaseAssignment.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
