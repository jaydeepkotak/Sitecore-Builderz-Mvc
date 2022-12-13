using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class ServiceModel
    {
        public List<Service> Service { get; set; }
        public Item Item { get; set; }
    }
    public class Service
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString Detail { get; set; }
        public MvcHtmlString Image { get; set; }
    }
   
}