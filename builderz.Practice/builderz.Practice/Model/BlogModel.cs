using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class BlogModel
    {
        public List<Blogcard> Blogcard { get; set; }
        public Item Item { get; set; }
    }
    public class Blogcard
    {
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString Blog_Name { get; set; }
        public MvcHtmlString Blog_Description { get; set; }
        public MvcHtmlString PostBy { get; set; }
        public MvcHtmlString In { get; set; }
    }
}