using Jobstacle.Shared.Domain;
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
					Name= "John",
					Email= "johntan@gmail.com",
					Gender= "Male",
					Resume= null,
					Location= "Tampines",
					ContactNumber= "98765432"
				}
			);
		}
	}
}