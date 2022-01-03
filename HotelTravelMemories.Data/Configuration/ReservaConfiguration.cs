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
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            builder.HasOne(r => r.Funcionario)
                .WithMany(f => f.Reservas)
                .HasForeignKey(r => r.FuncionarioId);

            builder.HasMany(r => r.Servicos)
                .WithOne(s => s.Reserva)
                .HasForeignKey(s => s.ReservaId);

            builder.HasOne(r => r.Quarto)
                .WithMany(q => q.Reservas)
                .HasForeignKey(r => r.QuartoId);

            builder.HasOne(r => r.Checkout)
                .WithOne(c => c.Reserva)
                .HasForeignKey<Reserva>(r => r.CheckoutId);

        }
    }
}
