using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class FAQModel
    {
        public List<FAQData> FAQData { get; set; }
        public Item Item { get; set; }
    }
    public class FAQData
    {
        public MvcHtmlString Question { get; set; }
        public MvcHtmlString Answer { get; set; }
    }
}