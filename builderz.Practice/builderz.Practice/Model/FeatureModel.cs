using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class FeatureModel
    {
        public List<Featuredata> Featuredata { get; set; }
    }
    public class Featuredata
    {
        public MvcHtmlString FlatIcon { get; set; }
        public MvcHtmlString Feature_Title { get; set; }
        public MvcHtmlString Feature_Description { get; set; }
    }
}