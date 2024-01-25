using CSharpSqlDataBaseAssignment.Contexts;
using CSharpSqlDataBaseAssignment.Entities;

namespace CSharpSqlDataBaseAssignment.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
