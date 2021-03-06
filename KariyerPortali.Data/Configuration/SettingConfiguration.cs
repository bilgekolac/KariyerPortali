﻿using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class SettingConfiguration:EntityTypeConfiguration<Setting>
    {
       public SettingConfiguration()
       {
           ToTable("Settings");
           HasKey<int>(c => c.SettingId);
           Property(c => c.Name).IsRequired().HasMaxLength(100);
           Property(c => c.Value).IsRequired();

       }
    }
}
