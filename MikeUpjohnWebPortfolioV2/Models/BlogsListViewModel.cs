using MikeUpjohnWebPortfolioV2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeUpjohnWebPortfolioV2.Models
{
    public class BlogsListViewModel
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogSummary { get; set; }
        public string BlogPost { get; set; }
        public string BlogImage { get; set; }
        public string BlogThumbnail { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime BlogCreatedDate { get; set; }

        public string DetailsLink
        {
            get
            {
                return "~/" + Settings.Pages.BLOGS + BlogDate.Year + "/" + BlogDate.Month.ToString("00") + "/" + Code.UsefulFunctions.SafeURL(BlogTitle);
            }
        }
    }
}