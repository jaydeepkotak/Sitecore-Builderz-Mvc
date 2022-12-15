using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class ContactModel
    {
        public List<ContactDetail> ContactDetail { get; set; }
        public Item Item { get; set; }
    }
    public class ContactDetail
    {
        public MvcHtmlString Main_Info { get; set; }
        public MvcHtmlString Sub_Info { get; set; }
        public MvcHtmlString FlatIcon { get; set; }
    }
}