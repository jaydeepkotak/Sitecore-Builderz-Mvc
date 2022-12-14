using builderz.Practice.Model;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace builderz.Practice.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
        // GET: About
        public ActionResult About()
        {
            //var datasourceItem = RenderingContext.Current?.Rendering.Item;
            //1. Pass Item to the view
            var model = new AboutViewModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            // 2. read the values, build the model and pass it to view
            // 3. read the values using fieldrenderer (support experience editor)
            return View(model);
        }
        // About Facts
        public ActionResult AboutFact()
        {
            var model = new AboutFactModel();
            List<Fact> facts = new List<Fact>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField factsField = dataSource.Fields["Cards"];

            var slideItems = factsField.GetItems();
            foreach (var slideItem in slideItems)
            {
                var score = new MvcHtmlString(FieldRenderer.Render(slideItem, "Score"));
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Title"));
                var factIcon = new MvcHtmlString(FieldRenderer.Render(slideItem, "FactIcon"));
                facts.Add(new Fact
                {
                    Score = score,
                    Title = title,
                    FactIcon = factIcon
                });
            }
            model.Fact = facts;
            return View(model);
        }
        public ActionResult FAQ()
        {
            var model = new FAQModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<FAQData> faqdata = new List<FAQData>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField faqField = dataSource.Fields["FAQ_Card"];
            var slideItems = faqField.GetItems();
            foreach (var slideItem in slideItems)
            {
                var question = new MvcHtmlString(FieldRenderer.Render(slideItem, "Question"));
                var answer = new MvcHtmlString(FieldRenderer.Render(slideItem, "Answer"));

                faqdata.Add(new FAQData
                {
                    Question = question,
                    Answer = answer,
                });
            }
            model.FAQData = faqdata;
            return View(model);
        }
        // Carousel
        public ActionResult Carousel()
        {
            var model = new CarouselModel();
            List<Slide> slides = new List<Slide>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["Slides"];

            //Rendering Parameters
            var slideCountParam = RenderingContext.Current?.Rendering.Parameters["SlideCount"];
            int.TryParse(slideCountParam, out int result);
            int slideCount = result == 0 ? 3 : result;

            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();
                foreach (var slideItem in slideItems.Take(slideCount))
                {
                    var titleField = slideItem.Fields["Title"];
                    var title = titleField?.Value;
                    var subTitle = new MvcHtmlString(FieldRenderer.Render(slideItem, "subTitle"));
                    var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));
                    var callToAction = new MvcHtmlString(FieldRenderer.Render(slideItem, "Call_To_Action", "class=btn animated fadeInUp"));

                    slides.Add(new Slide
                    {
                        Title = title,
                        SubTitle = subTitle,
                        Image = image,
                        CallToAction = callToAction
                    });
                }
                model.Slide = slides;
            }
            return View(model);
        }

        public ActionResult Team()
        {
            var model = new TeamModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<OurTeam> teams = new List<OurTeam>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField teamsField = dataSource.Fields["Cards"];
            Console.WriteLine(teamsField);
            var slideItems = teamsField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));
                var name = new MvcHtmlString(FieldRenderer.Render(slideItem, "Name"));
                var designatin = new MvcHtmlString(FieldRenderer.Render(slideItem, "Designation"));

                teams.Add(new OurTeam
                {
                    Image = image,
                    Name = name,
                    Designation = designatin

                });
            }
            model.OurTeam = teams;
            return View(model);
        }

        public ActionResult TopBar()
        {
            var model = new TopBarModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Top> tops = new List<Top>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField topsField = dataSource.Fields["TopList"];
            var slideItems = topsField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var flaticon = new MvcHtmlString(FieldRenderer.Render(slideItem, "Flaticon"));
                var contact = new MvcHtmlString(FieldRenderer.Render(slideItem, "Contact"));
                var contactdata = new MvcHtmlString(FieldRenderer.Render(slideItem, "ContactData"));

                tops.Add(new Top
                {
                    Flaticon = flaticon,
                    Contact = contact,
                    ContactData = contactdata

                });
            }
            model.Top = tops;
            return View(model);
        }

        public ActionResult Navigation()
        {
            var model = new NavigationModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Navigation> navigations = new List<Navigation>();
            List<NavigationChild> navigationschild = new List<NavigationChild>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField navigationsField = dataSource.Fields["Links"];
            MultilistField childnavigationsField = dataSource.Fields["ChildLink"];
            var slideItems = navigationsField.GetItems();
            var slideItemschild = childnavigationsField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "NavigationTitle"));
                var link = new MvcHtmlString(FieldRenderer.Render(slideItem, "NavigationLink"));

                navigations.Add(new Navigation
                {
                    NavigationTitle = title,
                    NavigationLink = link,
                });
            }
            model.Navigation = navigations;
            foreach (var childslideItem in slideItemschild)
            {
                var childtitle = new MvcHtmlString(FieldRenderer.Render(childslideItem, "Child_Navigation_Title"));
                var childlink = new MvcHtmlString(FieldRenderer.Render(childslideItem, "Child_Navigation_Link"));

                navigationschild.Add(new NavigationChild
                {
                    ChildNavigationTitle = childtitle,
                    ChildNavigationLink = childlink,
                });
            }
            model.NavigationChild = navigationschild;
            return View(model);
        }

        public ActionResult Service()
        {
            var model = new ServiceModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Service> services = new List<Service>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField serviceField = dataSource.Fields["Cards"];
            Console.WriteLine(serviceField);
            var slideItems = serviceField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Title"));
                var detail = new MvcHtmlString(FieldRenderer.Render(slideItem, "Detail"));
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));

                services.Add(new Service
                {
                    Title = title,
                    Detail = detail,
                    Image = image

                });
            }
            model.Service = services;
            return View(model);
        }

        public ActionResult Portfolio()
        {
            var model = new PortfolioModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Portfolio> portfolios = new List<Portfolio>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField portfolioField = dataSource.Fields["Cards"];
            Console.WriteLine(portfolioField);
            var slideItems = portfolioField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Title"));
                var detail = new MvcHtmlString(FieldRenderer.Render(slideItem, "Detail"));
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));

                portfolios.Add(new Portfolio
                {
                    Title = title,
                    Detail = detail,
                    Image = image

                });
            }
            model.Portfolio = portfolios;
            return View(model);
        }

        public ActionResult Footer()
        {

            var model = new FooterModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Footer> footers = new List<Footer>();
            List<SocailIcon> socailicons = new List<SocailIcon>();
            List<UsefulLink> usefullinks = new List<UsefulLink>();
            List<ServiceLink> servicelinks = new List<ServiceLink>();
            List<ContainerLink> containerlinks = new List<ContainerLink>();

            var dataSource = RenderingContext.Current?.Rendering.Item;

            MultilistField socailField = dataSource.Fields["Social_Icon"];
            MultilistField footerField = dataSource.Fields["Office_Contact"];
            MultilistField linkField = dataSource.Fields["Useful_Link"];
            MultilistField servicelinkField = dataSource.Fields["Service_Area_Link"];
            MultilistField containerlinkField = dataSource.Fields["Container_Link"];
            var slideItems = footerField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var icon = new MvcHtmlString(FieldRenderer.Render(slideItem, "FlatIcon"));
                var office_data = new MvcHtmlString(FieldRenderer.Render(slideItem, "Office_Data"));

                footers.Add(new Footer
                {
                    FlatIcon = icon,
                    Office_Data = office_data,

                });
            }
            model.Footer = footers;

            var slideItemsIcons = socailField.GetItems();

            foreach (var slideItemsIcon in slideItemsIcons)
            {
                var socialicon = new MvcHtmlString(FieldRenderer.Render(slideItemsIcon, "Social_Icon"));

                socailicons.Add(new SocailIcon
                {
                    Social_Icon = socialicon,
                });
            }
            model.SocailIcon = socailicons;

            var slideItemsLink = linkField.GetItems();

            foreach (var slideItemslink in slideItemsLink)
            {
                var footerlink = new MvcHtmlString(FieldRenderer.Render(slideItemslink, "Footer_links"));

                usefullinks.Add(new UsefulLink
                {
                    Footer_links = footerlink,
                });
            }
            model.UsefulLink = usefullinks;

            var slideItemsServiceLink = servicelinkField.GetItems();

            foreach (var slideItemsServiceLinks in slideItemsServiceLink)
            {
                var servicelink = new MvcHtmlString(FieldRenderer.Render(slideItemsServiceLinks, "Service_Link"));

                servicelinks.Add(new ServiceLink
                {
                    Service_Link = servicelink,
                });
            }
            model.ServiceLink = servicelinks;
            return View(model);
        }
        public ActionResult FooterContainer()
        {

            var model = new FooterModel();
            List<ContainerLink> containerlinks = new List<ContainerLink>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField containerlinkField = dataSource.Fields["Container_Link"];
            var slideItemsContainer = containerlinkField.GetItems();

            foreach (var slideItemcontainerlink in slideItemsContainer)
            {

                var containerlink = new MvcHtmlString(FieldRenderer.Render(slideItemcontainerlink, "Link_Container"));

                containerlinks.Add(new ContainerLink
                {
                    Link_Container = containerlink,
                });
            }
            model.ContainerLink = containerlinks;
            return View(model);
        }

        public ActionResult Feature()
        {
            var model = new FeatureModel();
            List<Featuredata> featuredata = new List<Featuredata>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField featureField = dataSource.Fields["Feature_card"];
            var slideItems = featureField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var flaticon = new MvcHtmlString(FieldRenderer.Render(slideItem, "FlatIcon"));
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Feature_Title"));
                var description = new MvcHtmlString(FieldRenderer.Render(slideItem, "Feature_Description"));
                featuredata.Add(new Featuredata
                {
                    FlatIcon = flaticon,
                    Feature_Title = title,
                    Feature_Description = description
                });
            }
            model.Featuredata = featuredata;
            return View(model);
        }
        //Single Page
        public ActionResult SinglePost()
        {
            var model = new SinglePostModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<SinglePost> singleposts = new List<SinglePost>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField postField = dataSource.Fields["PostData"];
            var slideItems = postField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Title"));
                var description = new MvcHtmlString(FieldRenderer.Render(slideItem, "Description"));
                singleposts.Add(new SinglePost
                {
                    Title = title,
                    Description = description,
                });
            }
            model.SinglePost = singleposts;
            return View(model);
        }
        //Single Page
        public ActionResult RecentPost()
        {
            var model = new SinglePostModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<RecentPost> recentposts = new List<RecentPost>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField recentField = dataSource.Fields["Post_Data"];
            var slideItems = recentField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));
                var titlelink = new MvcHtmlString(FieldRenderer.Render(slideItem, "TitleLink"));
                var postby = new MvcHtmlString(FieldRenderer.Render(slideItem, "PostBy"));
                var In = new MvcHtmlString(FieldRenderer.Render(slideItem, "In"));

                recentposts.Add(new RecentPost
                {
                    Image = image,
                    TitleLink = titlelink,
                    PostBy = postby,
                    In = In,
                });
            }
            model.RecentPost = recentposts;
            return View(model);
        }
        //Single Page
        public ActionResult SinglePageButton()
        {
            var model = new SinglePostModel();
            List<Buttons> buttons = new List<Buttons>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField buttonField = dataSource.Fields["ButtonList"];
            var slideItems = buttonField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var buttonlink = new MvcHtmlString(FieldRenderer.Render(slideItem, "ButtonLink"));
                buttons.Add(new Buttons
                {
                    ButtonLink = buttonlink,
                });
            }
            model.Buttons = buttons;
            return View(model);
        }
        //Single Page
        public ActionResult SinglePageCategories()
        {
            var model = new SinglePostModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Categories> categories = new List<Categories>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField CategoriesField = dataSource.Fields["Categories_List"];
            var slideItems = CategoriesField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var categories_Link = new MvcHtmlString(FieldRenderer.Render(slideItem, "Categories_Link"));
                var categories_Count = new MvcHtmlString(FieldRenderer.Render(slideItem, "Categories_Count"));
                categories.Add(new Categories
                {
                    Categories_Link = categories_Link,
                    Categories_Count = categories_Count,
                });
            }
            model.Categories = categories;
            return View(model);
        }
        //Single Page
        public ActionResult SinglePageTagsCloud()
        {
            var model = new SinglePostModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<TagsCloud> tagsclouds = new List<TagsCloud>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField tagscloudField = dataSource.Fields["Tags_Cloud_List"];
            var slideItems = tagscloudField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var buttonlink = new MvcHtmlString(FieldRenderer.Render(slideItem, "Button_Link"));
                tagsclouds.Add(new TagsCloud
                {
                    Button_Link = buttonlink,
                });
            }
            model.TagsCloud = tagsclouds;
            return View(model);
        }

        //Single Page
        public ActionResult RelatedPost()
        {
            var model = new SinglePostModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<RelatedPost> relatedPosts = new List<RelatedPost>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField relatedField = dataSource.Fields["Cards"];
            var slideItems = relatedField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));
                var titlelink = new MvcHtmlString(FieldRenderer.Render(slideItem, "TitleLink"));
                var postby = new MvcHtmlString(FieldRenderer.Render(slideItem, "PostBy"));
                var In = new MvcHtmlString(FieldRenderer.Render(slideItem, "In"));

                relatedPosts.Add(new RelatedPost
                {
                    Image = image,
                    TitleLink = titlelink,
                    PostBy = postby,
                    In = In,
                });
            }
            model.RelatedPost = relatedPosts;
            return View(model);
        }

        public ActionResult Blog()
        {
            var model = new BlogModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            List<Blogcard> blogcards = new List<Blogcard>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField blogField = dataSource.Fields["Cards"];
            var slideItems = blogField.GetItems();

            foreach (var slideItem in slideItems)
            {
                var image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Image"));
                var name = new MvcHtmlString(FieldRenderer.Render(slideItem, "Blog_Name"));
                var description = new MvcHtmlString(FieldRenderer.Render(slideItem, "Blog_Description"));
                var postby = new MvcHtmlString(FieldRenderer.Render(slideItem, "PostBy"));
                var In = new MvcHtmlString(FieldRenderer.Render(slideItem, "In"));

                blogcards.Add(new Blogcard
                {
                    Image = image,
                    Blog_Name = name,
                    Blog_Description = description,
                    PostBy = postby,
                    In = In,
                });
            }
            model.Blogcard = blogcards;
            return View(model);
        }


    }
}