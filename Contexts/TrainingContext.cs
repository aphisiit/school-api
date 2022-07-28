using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SchoolAPI.Models;

namespace SchoolAPI.Contexts
{
	public class TrainingContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }

		public TrainingContext(DbContextOptions<TrainingContext> options)
		: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseNpgsql("Host=localhost;Database=my_data;Username=user;Password=password");
		}
	}
}

