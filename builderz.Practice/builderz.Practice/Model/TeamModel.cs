using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class TeamModel
    {
        public List<OurTeam> OurTeam { get; set; }
        public Item Item { get; set; }
    }
    public class OurTeam
    {
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString Name { get; set; }
        public MvcHtmlString Designation { get; set; }
    }
}