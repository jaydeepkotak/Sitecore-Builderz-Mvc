using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class CarouselModel
    {
        public List<Slide> Slide { get; set; }
    }
    public class Slide
    {
        public String Title { get; set; }
        public MvcHtmlString SubTitle { get; set; }
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString CallToAction { get; set; }
    }
}