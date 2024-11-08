using CapstoneGenerator.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneGenerator.Server.Data.Configurations
{
    public class CapstoneConfig : IEntityTypeConfiguration<Capstones>
    {
        public void Configure(EntityTypeBuilder<Capstones> builder)
        {
            builder
                .HasKey(c => c.CapstoneId);
        }
    }
}
