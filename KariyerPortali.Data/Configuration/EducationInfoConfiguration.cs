﻿using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class EducationInfoConfiguration:EntityTypeConfiguration<EducationInfo>
    {
        public EducationInfoConfiguration()
        {
            ToTable("EducationInfos");
            HasKey<int>(c => c.EducationInfoId);
       
        }
    }
}

