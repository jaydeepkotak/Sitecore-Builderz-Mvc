using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class FooterModel
    {
        public List<Footer> Footer { get; set; }
        public List<SocailIcon> SocailIcon { get; set; }
        public List<UsefulLink> UsefulLink { get; set; }
        public List<ServiceLink> ServiceLink { get; set; }
        public List<ContainerLink> ContainerLink { get; set; }
        public Item Item { get; set; }
    }
    public class Footer
    {
        public MvcHtmlString FlatIcon { get; set; }
        public MvcHtmlString Office_Data { get; set; }
    }
    public class SocailIcon
    {
        public MvcHtmlString Social_Icon { get; set; }
    }
    public class UsefulLink
    {
        public MvcHtmlString Footer_links { get; set; }
    }
    public class ServiceLink
    {
        public MvcHtmlString Service_Link { get; set; }
    }
    public class ContainerLink
    {
        public MvcHtmlString Link_Container { get; set; }
    }
}