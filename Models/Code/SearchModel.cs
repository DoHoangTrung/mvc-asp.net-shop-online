using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.Code
{
    public class SearchModel
    {
        public string keyWords { get; set; }

        public int? fromNumber { get; set; }
        public int? toNumber { get; set; }

        public int? typeId { get; set; }


    }
}