using MikeUpjohnWebPortfolioV2.Code;
using MikeUpjohnWebPortfolioV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.BodyClass = Code.Settings.BodyClass.HOMEPAGE;
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _LatestProject()
        {
            using (MikeUpjohnCMSEntities db = new MikeUpjohnCMSEntities())
            {
                //var project = db.Projects.OrderBy(x => x.ProjectPostDate).Take(1).SingleOrDefault();
                ProjectsListViewModel project = (from x in db.Projects
                                                 join y in db.Images on x.ProjectImageID equals y.ImageID into ya
                                                 from y in ya.DefaultIfEmpty()
                                                 join z in db.Images on x.ProjectThumbnailImageID equals z.ImageID into za
                                                 from z in za.DefaultIfEmpty()
                                                 orderby x.ProjectPostDate
                                                 select new ProjectsListViewModel
                                                 {
                                                     ProjectID = x.ProjectID,
                                                     ProjectTitle = x.ProjectTitle,
                                                     ProjectDateDescription = x.ProjectDateDescription,
                                                     ProjectPostDate = x.ProjectPostDate,
                                                     ProjectSummary = x.ProjectSummary,
                                                     ProjectDescription = x.ProjectDescription,
                                                     ProjectLink = x.ProjectLink,
                                                     ProjectImage = (y != null ? Settings.UPLOADSIMAGEFILEPATH + y.ImageFileName : Settings.DEFAULTIMAGEFILEPATH),
                                                     ProjectThumbnailImage = (z != null ? Settings.UPLOADSIMAGEFILEPATH + z.ImageFileName : Settings.DEFAULTIMAGEFILEPATH),
                                                     IsDisabled = x.IsDisabled,
                                                     IsDeleted = x.IsDeleted,
                                                     ProjectCreatedDate = x.ProjectCreatedDate
                                                 }).FirstOrDefault();

                return PartialView(project);
            }
        }

        [ChildActionOnly]
        public PartialViewResult _LatestBlog()
        {
            using (MikeUpjohnCMSEntities db = new MikeUpjohnCMSEntities())
            {
                BlogsListViewModel blog = (from x in db.Blogs
                                           join y in db.Images on x.BlogImageID equals y.ImageID into ya
                                           from y in ya.DefaultIfEmpty()
                                           join z in db.Images on x.BlogThumbnailImageID equals z.ImageID into za
                                           from z in za.DefaultIfEmpty()
                                           orderby x.BlogDate
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
                                           }).FirstOrDefault();

                return PartialView(blog);
            }
        }
    }
}