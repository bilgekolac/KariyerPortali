﻿using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class PageConfiguration:EntityTypeConfiguration<Page>
    {
       public PageConfiguration()
       {
           ToTable("Pages");
           HasKey<int>(p => p.PageId);
           Property(p => p.Title).IsRequired().HasMaxLength(100);
           Property(p => p.Slug).HasMaxLength(500);
           Property(p => p.Body).IsRequired();
           Property(p => p.ViewCount).IsRequired();
           Property(p => p.CreatedBy).IsRequired().HasMaxLength(100);
           Property(p => p.CreateDate).IsRequired();
           Property(p => p.UpdatedBy).IsRequired().HasMaxLength(100);
           Property(p => p.UpdateDate).IsRequired();
           Property(p => p.PageOrder);
           Property(p => p.ParentPageId);
       }
    }
}
