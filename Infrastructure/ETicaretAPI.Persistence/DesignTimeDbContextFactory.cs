using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
	{
		//PowerShell üzerinden talimat verebilmek için oluşturulmuş bir sınıftır. 
		// design time hatasına istinaden hazırlanmıştır.
		public ETicaretAPIDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
			return new(dbContextOptionsBuilder.Options);
		}
	}
}
