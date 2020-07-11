using MikeUpjohnWebPortfolioV2.Code;
using MikeUpjohnWebPortfolioV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index(int? page)
        {
            int pageNumber = page != null ? (int)page : 1;
            using (MikeUpjohnCMSEntities db = new MikeUpjohnCMSEntities())
            {
                var blogs = (from x in db.Blogs
                             join y in db.Images on x.BlogImageID equals y.ImageID into ya
                             from y in ya.DefaultIfEmpty()
                             join z in db.Images on x.BlogThumbnailImageID equals z.ImageID into za
                             from z in za.DefaultIfEmpty()
                             where !x.IsDisabled && !x.IsDeleted
                                orderby x.BlogDate descending
                                select new BlogsListViewModel
                                {
                                    BlogID = x.BlogID,
                                    BlogTitle = x.BlogTitle,
                                    BlogAuthor = x.BlogAuthor,
                                    BlogDate = x.BlogDate,
                                    BlogSummary = x.BlogSummary,
                                    BlogPost = x.BlogPost,
                                    BlogImage = (y != null ? Settings.UPLOADSIMAGEFILEPATH + y.ImageFileName : Settings.DEFAULTIMAGEFILEPATH),
                                    BlogThumbnail = (z != null ? Settings.UPLOADSIMAGEFILEPATH + z.ImageFileName : Settings.DEFAULTIMAGEFILEPATH),
                                    IsDisabled = x.IsDisabled,
                                    IsDeleted = x.IsDeleted,
                                    BlogCreatedDate = x.BlogCreatedDate
                                }).ToList();

                ViewBag.CurrentPage = pageNumber;
                ViewBag.CountOfItems = blogs.Count();
                ViewBag.BodyClass = Settings.BodyClass.BLOGS;

                return View(blogs.Skip((pageNumber - 1) * Settings.PAGINATIONITEMSPERPAGE).Take(Settings.PAGINATIONITEMSPERPAGE).ToList());
            }
        }

        public ActionResult View(string year, string month, string title)
        {
            int blogYear = 0;
            int blogMonth = 0;

            if (int.TryParse(year, out blogYear) && int.TryParse(month, out blogMonth))
            {

                using (MikeUpjohnCMSEntities db = new MikeUpjohnCMSEntities())
                {
                    var blogs = (from x in db.Blogs
                                 join y in db.Images on x.BlogImageID equals y.ImageID into ya
                                 from y in ya.DefaultIfEmpty()
                                 join z in db.Images on x.BlogThumbnailImageID equals z.ImageID into za
                                 from z in za.DefaultIfEmpty()
                                 where !x.IsDisabled && !x.IsDeleted
                                 orderby x.BlogDate descending
                                 select new BlogsListViewModel
                                 {
                                     BlogID = x.BlogID,
                                     BlogTitle = x.BlogTitle,
                                     BlogAuthor = x.BlogAuthor,
                                     BlogDate = x.BlogDate,
                                     BlogSummary = x.BlogSummary,
                                     BlogPost = x.BlogPost,
                                     BlogImage = (y != null ? Settings.UPLOADSIMAGEFILEPATH + y.ImageFileName : ""),
                                     BlogThumbnail = (z != null ? Settings.UPLOADSIMAGEFILEPATH + z.ImageFileName : ""),
                                     IsDisabled = x.IsDisabled,
                                     IsDeleted = x.IsDeleted,
                                     BlogCreatedDate = x.BlogCreatedDate
                                 }).ToList();


                    var blog = blogs.Where(x => x.BlogDate.Year == blogYear && x.BlogDate.Month == blogMonth && Code.UsefulFunctions.SafeURL(x.BlogTitle) == title).SingleOrDefault();

                    if (blog != null)
                    {
                        ViewBag.BodyClass = Settings.BodyClass.DETAILSPAGE;
                        return View(blog);
                    }
                }
            }
 
            return RedirectToAction("Index", "Blogs");
        }
    }
}