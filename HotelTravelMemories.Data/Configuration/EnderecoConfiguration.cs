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
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Funcionario)
                .WithOne(f => f.Endereco)
                .HasForeignKey<Endereco>(e => e.FuncionarioId);

            builder.HasOne(e => e.Cliente)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Endereco>(e => e.ClienteId);
        }
    }
}
