using CSharpSqlDataBaseAssignment.Contexts;
using CSharpSqlDataBaseAssignment.Entities;

namespace CSharpSqlDataBaseAssignment.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
