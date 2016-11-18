using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Helpers
{
    public static class TimeFormatHelper
    {
        public static string TimeFormat(this HtmlHelper helper, DateTime Date)
        {
            if (Convert.ToInt32((DateTime.Now-Date).TotalSeconds) < 60)
            {
                return string.Format("{0} saniye önce", Math.Round((DateTime.Now - Date).TotalSeconds));
            }
            else if (Convert.ToInt32((DateTime.Now-Date).TotalSeconds)>=60 && Convert.ToInt32((DateTime.Now - Date).TotalSeconds) <= 3600)
            {
                return string.Format("{0} dakika önce", Math.Round((DateTime.Now - Date).TotalMinutes));
            }

            else
            {
                return string.Format("{0} saat önce", Math.Round((DateTime.Now - Date).TotalHours));
            }
        }
    }
}