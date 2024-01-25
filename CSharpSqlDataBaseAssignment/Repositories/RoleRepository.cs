using CSharpSqlDataBaseAssignment.Contexts;
using CSharpSqlDataBaseAssignment.Entities;

namespace CSharpSqlDataBaseAssignment.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}