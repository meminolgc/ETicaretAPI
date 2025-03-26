using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
	{
		public ETicaretAPIDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
			return new(dbContextOptionsBuilder.Options);
		}
	}
}
//PowerShell üzerinden talimat verebilmek için oluşturulmuş bir sınıftır. 
// design time hatasına istinaden hazırlanmıştır.