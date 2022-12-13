using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class TopBarModel
    {
        public List<Top> Top { get; set; }
        public Item Item { get; set; }
    }
    public class Top
    {
        public MvcHtmlString Flaticon { get; set; }
        public MvcHtmlString Contact { get; set; }
        public MvcHtmlString ContactData { get; set; }
    }
}