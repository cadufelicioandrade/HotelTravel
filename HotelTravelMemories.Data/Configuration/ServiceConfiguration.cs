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
    public class ServiceConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Reserva)
                .WithMany(r => r.Servicos)
                .HasForeignKey(s => s.ReservaId);
        }
    }
}
