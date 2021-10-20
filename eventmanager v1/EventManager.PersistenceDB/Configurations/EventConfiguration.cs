using EventManager.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.PersistenceDB.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {

            builder.ToTable("Events");


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsUnicode(false).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Title).IsUnicode(false).IsRequired().HasMaxLength(20);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.isPublished).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Events);
        }


    }
}
