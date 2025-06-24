using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal class RoomCleanerConfiguration : IEntityTypeConfiguration<RoomCleaner>
{
    public void Configure(EntityTypeBuilder<RoomCleaner> builder)
    {
        builder.HasKey(rc => new { rc.RoomId, rc.CleanerId });
        builder.HasOne<Room>().WithMany(r => r.RoomCleaners).HasForeignKey(rc => rc.RoomId);
        builder.HasOne<Cleaner>().WithMany(r => r.RoomCleaners).HasForeignKey(rc => rc.CleanerId);
    }
}

