﻿using Jobstacle.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jobstacle.Server.Configurations.Entities
{
	public class JobSeekerSeedConfiguration : IEntityTypeConfiguration<JobSeeker>
	{
		public void Configure(EntityTypeBuilder<JobSeeker> builder)
		{
			builder.HasData(
				new JobSeeker
				{
					Id = 1,
					JobSeekerPic= null,
					Name= "John",
					Email= "johntan@gmail.com",
					Gender= "Male",
					Resume= "johntan_resume.pdf",
					Location= "Tampines",
					ContactNumber= "98765432"
				}
			);
		}
	}
}