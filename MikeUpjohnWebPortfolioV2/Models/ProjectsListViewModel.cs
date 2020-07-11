using MikeUpjohnWebPortfolioV2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeUpjohnWebPortfolioV2.Models
{
    public class ProjectsListViewModel
    {
        public int ProjectID { get; set;}
        public string ProjectTitle { get; set; }
        public string ProjectDateDescription { get; set; }
        public DateTime ProjectPostDate { get; set; }
        public string ProjectSummary { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectLink { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectThumbnailImage { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ProjectCreatedDate { get; set; }

        public string DetailsLink
        {
            get
            {
                return "~/" + Settings.Pages.PROJECTS + ProjectPostDate.Year + "/" + ProjectPostDate.Month.ToString("00") + "/" + Code.UsefulFunctions.SafeURL(ProjectTitle);
            }
        }
    }
}