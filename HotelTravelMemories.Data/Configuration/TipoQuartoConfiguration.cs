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
    public class TipoQuartoConfiguration : IEntityTypeConfiguration<TipoQuarto>
    {
        public void Configure(EntityTypeBuilder<TipoQuarto> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Quartos)
                .WithOne(q => q.TipoQuarto)
                .HasForeignKey(t => t.TipoQuartoId);
        }
    }
}
