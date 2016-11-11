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
            Property(n => n.Detail).IsOptional();
            Property(n => n.NotificationDate).IsRequired();
            Property(n => n.param1).IsOptional();
            Property(n => n.param2).IsOptional();
            Property(n => n.param3).IsOptional();
            Property(n => n.NotificationType).IsRequired();
        }
    }
}
