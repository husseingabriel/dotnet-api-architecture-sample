using Coworking.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.EntityConfig
{
    public class Room2ServiceConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Room2ServicesEntity> entityBuilder)
        {
            entityBuilder.ToTable("Room2Service");

            entityBuilder.HasOne(x => x.Room).WithMany(x => x.Room2Service).HasForeignKey(x=>x.IdRoom);
            entityBuilder.HasOne(x => x.Service).WithMany(x => x.Room2Service).HasForeignKey(x => x.IdService);

            entityBuilder.HasKey(x => new { x.IdRoom, x.IdService });
            entityBuilder.Property(x => x.IdRoom).IsRequired();
            entityBuilder.Property(x => x.IdService).IsRequired();

        }
    }
}
