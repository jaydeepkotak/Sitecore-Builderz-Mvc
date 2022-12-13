using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class NavigationModel
    {
        public List<Navigation> Navigation { get; set; }
        public List<NavigationChild> NavigationChild { get; set; }
        public Item Item { get; set; }
    }
    public class Navigation
    {
        public MvcHtmlString NavigationTitle { get; set; }
        public MvcHtmlString NavigationLink { get; set; }
    }
    public class NavigationChild
    {
        public MvcHtmlString ChildNavigationTitle { get; set; }
        public MvcHtmlString ChildNavigationLink { get; set; }
    }

}