using HotelTravelMemories.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Configuration
{
    public class QuartoConfiguration : IEntityTypeConfiguration<Quarto>
    {
        public void Configure(EntityTypeBuilder<Quarto> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasMany(q => q.Reservas)
                .WithOne(r => r.Quarto)
                .HasForeignKey(r => r.QuartoId);
        }
    }
}
