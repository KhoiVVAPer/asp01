using Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class ApiDBContext : DbContext
	{
		public ApiDBContext() : base("ApiConnection1")
		{

		}
		static ApiDBContext()
		{
			Database.SetInitializer<ApiDBContext>(new IdentityDbInit());
		}

		public static ApiDBContext Create()
		{
			return new ApiDBContext();
		}

		public DbSet<Classes> Class { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teacher { get; set; }
        public DbSet<HoatDongGiangDay> HDGD { get; set; }
		public override int SaveChanges()
		{
			//

			return base.SaveChanges();
		}
	}

	internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApiDBContext>
	{
		public void Seed(ApiDBContext context)
		{
			PerformInit();
			base.Seed(context);
		}

		public void PerformInit()
		{

		}
	}
}
