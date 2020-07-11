using MikeUpjohnWebPortfolioV2.Code;
using MikeUpjohnWebPortfolioV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult Index(int? page)
        {
            int pageNumber = page != null ? (int)page : 1;
            using (MikeUpjohnCMSEntities db = new MikeUpjohnCMSEntities())
            {
                var projects = (from x in db.Projects
                                join y in db.Images on x.ProjectImageID equals y.ImageID into ya
                                from y in ya.DefaultIfEmpty()
                                join z in db.Images on x.ProjectThumbnailImageID equals z.ImageID into za
                                from z in za.DefaultIfEmpty()
                                where !x.IsDisabled && !x.IsDeleted
                                orderby x.ProjectPostDate descending
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
                                    ProjectThumbnailImage = (z!= null ? Settings.UPLOADSIMAGEFILEPATH + z.ImageFileName : Settings.DEFAULTIMAGEFILEPATH),
                                    IsDisabled = x.IsDisabled,
                                    IsDeleted = x.IsDeleted,
                                    ProjectCreatedDate = x.ProjectCreatedDate
                                }).ToList();

                ViewBag.CurrentPage = pageNumber;
                ViewBag.CountOfItems = projects.Count();
                ViewBag.BodyClass = Settings.BodyClass.PROJECTS;

                return View(projects.Skip((pageNumber - 1) * 10).Take(10).ToList());
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
                    var projects = (from x in db.Projects
                                    join y in db.Images on x.ProjectImageID equals y.ImageID
                                    join z in db.Images on x.ProjectThumbnailImageID equals z.ImageID
                                    where !x.IsDisabled && !x.IsDeleted
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
                                        ProjectImage = Settings.UPLOADSIMAGEFILEPATH + y.ImageFileName,
                                        ProjectThumbnailImage = Settings.UPLOADSIMAGEFILEPATH + z.ImageFileName,
                                        IsDisabled = x.IsDisabled,
                                        IsDeleted = x.IsDeleted,
                                        ProjectCreatedDate = x.ProjectCreatedDate
                                    }).ToList();

                    var project = projects.Where(x => x.ProjectPostDate.Year == blogYear && x.ProjectPostDate.Month == blogMonth && Code.UsefulFunctions.SafeURL(x.ProjectTitle) == title).SingleOrDefault();

                    if (project != null)
                    {
                        ViewBag.BodyClass = Settings.BodyClass.DETAILSPAGE;
                        return View(project);
                    }
                }
            }

            return RedirectToAction("Index", "Projects");
        }
    }
}