using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
	public class ProductSeed : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(
				new Product { Id = 1,CategoryId=1, Name = "Elma",Stock=1,Price=5,CreatedDate=DateTime.Now },
				new Product { Id = 2, CategoryId = 1, Name = "Muz", Stock = 1, Price = 3, CreatedDate = DateTime.Now },
				new Product { Id = 3, CategoryId = 1, Name = "Musmula", Stock = 1, Price = 10, CreatedDate = DateTime.Now });

		}
	}
}

