using Jobstacle.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jobstacle.Server.Configurations.Entities
{
	public class OrganizerSeedConfiguration : IEntityTypeConfiguration<Organizer>
	{
		public void Configure(EntityTypeBuilder<Organizer> builder)
		{
			builder.HasData(
				new Organizer
				{
					Id = 1,
					OrgLogo = null,
					Name = "OrgY",
					Email = "OrgY@gmail.com",
					ContactNumber = "98765432",
					Description= "The best Y there is."
				}
			);
		}
	}
}