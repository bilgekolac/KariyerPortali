using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class PostViewModel
    {
       
            public int PostId { get; set; }
        [DisplayName("Başlık Adı")]
            public string Title { get; set; }
        [DisplayName("İçerik")]
            public string Body { get; set; }

        
    }
}