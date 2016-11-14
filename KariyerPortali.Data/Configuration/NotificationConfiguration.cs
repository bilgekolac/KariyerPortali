using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class NotificationConfiguration: EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            ToTable("Notifications");
            HasKey<int>(n => n.NotificationId);
            Property(n => n.Message).IsOptional().HasMaxLength(200);
            Property(n => n.Details).IsOptional();
            Property(n => n.NotificationDate).IsRequired();
            Property(n => n.Param1).IsOptional();
            Property(n => n.Param2).IsOptional();
            Property(n => n.Param3).IsOptional();
            Property(n => n.NotificationType).IsRequired();
        }
    }
}
