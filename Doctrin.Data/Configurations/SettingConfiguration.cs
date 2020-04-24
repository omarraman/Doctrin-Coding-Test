﻿using Doctrin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctrin.Data.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasIndex(u => new {u.UnitId, u.GlobalId}).IsUnique();
            builder.HasData(new Setting {Id = 1, GlobalId = "Opening Hours",UnitId=1,Value="9:00-17:00" });
        }
    }
}
