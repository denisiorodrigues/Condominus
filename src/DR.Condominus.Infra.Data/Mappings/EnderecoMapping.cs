using DR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Condominus.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(p => p.Complemento)
                .HasMaxLength(100);

            HasRequired(c => c.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");
        }
    }
}
