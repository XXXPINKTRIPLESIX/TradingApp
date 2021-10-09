using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Data.Configurators
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Login).HasColumnName("login").IsRequired();
            builder.Property(p => p.Password).HasColumnName("password").IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").IsRequired();
            builder.OwnsOne(p => p.PersonalData, parameter => 
            {
                parameter.Property(p => p.Name).HasColumnName("user_name").IsRequired();
                parameter.Property(p => p.LastName).HasColumnName("user_last_name").IsRequired();
                parameter.Property(p => p.Surname).HasColumnName("user_surname").IsRequired();
                parameter.Property(p => p.PhoneNumber).HasColumnName("user_phone_number").IsRequired();
                parameter.Property(p => p.Description).HasColumnName("user_description").IsRequired();
            });
        }
    }
}
