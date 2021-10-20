using EventManager.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.PersistenceDB.Configurations
{
    class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");


            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsUnicode(false).IsRequired().HasMaxLength(80).IsFixedLength();
            builder.Property(x => x.LastName).IsUnicode(false).IsRequired().HasMaxLength(20).IsFixedLength();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder.HasMany(x => x.Events)
                .WithOne(x => x.User);
        }
    }
}
