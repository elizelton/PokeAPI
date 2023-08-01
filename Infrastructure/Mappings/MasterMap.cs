using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class MasterMap : IEntityTypeConfiguration<Master>
{
    public void Configure(EntityTypeBuilder<Master> builder)
    {
        builder.ToTable("Masters");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder.HasMany(m  => m.Pokemons)
            .WithOne(p => p.Master)
            .HasForeignKey(p => p.MasterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}