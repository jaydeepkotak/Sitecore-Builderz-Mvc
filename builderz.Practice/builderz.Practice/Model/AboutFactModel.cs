using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class AboutFactModel
    {
        public List<Fact> Fact { get; set; }
    }
    public class Fact
    {
        public MvcHtmlString Score { get; set; }
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString FactIcon { get; set; }

    }
}