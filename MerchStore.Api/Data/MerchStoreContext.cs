using System.Reflection;
using MerchStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchStore.Api.Data;

/*represents a session with the db and can be
  used to query and set instances of our entities*/
public class MerchStoreContext: DbContext
{
    public MerchStoreContext(DbContextOptions<MerchStoreContext> options)
        : base(options)
    {        
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}