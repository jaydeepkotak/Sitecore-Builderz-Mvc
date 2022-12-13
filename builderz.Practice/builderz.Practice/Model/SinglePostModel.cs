using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Model
{
    public class SinglePostModel
    {
        public List<SinglePost> SinglePost { get; set; }
        public List<RecentPost> RecentPost { get; set; }
        public List<Buttons> Buttons { get; set; }
        public List<Categories> Categories { get; set; }
        public List<TagsCloud> TagsCloud { get; set; }
        public List<RelatedPost> RelatedPost { get; set; }
        public Item Item { get; set; }
    }
    public class SinglePost
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString Description { get; set; }
    }
    public class RecentPost
    {
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString TitleLink { get; set; }
        public MvcHtmlString PostBy { get; set; }
        public MvcHtmlString In { get; set; }
    }
    public class Buttons
    {
        public MvcHtmlString ButtonLink { get; set; }
    }
    public class Categories
    {
        public MvcHtmlString Categories_Link { get; set; }
        public MvcHtmlString Categories_Count { get; set; }
    }
    public class TagsCloud
    {
        public MvcHtmlString Button_Link { get; set; }
    }
    public class RelatedPost
    {
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString TitleLink { get; set; }
        public MvcHtmlString PostBy { get; set; }
        public MvcHtmlString In { get; set; }
    }
}