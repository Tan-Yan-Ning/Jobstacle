using Jobstacle.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Jobstacle.Server.Configurations.Entities
{
    public class CompanySeedConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1, 
                    ComLogo = null,
                    Name = "X",
                    ContactNumber = "78646468",
                    Email = "companyX@gmail.com",
                    Description = "The best X there is.",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
           
                );
        }
    }
}
