using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MikeUpjohnWebPortfolioV2.Code
{
    public class Settings
    {
        public static int PAGINATIONITEMSPERPAGE = 10;
        public static int PAGINATIONOFFSETITEMCOUNT = 3;
        public static string HTMLNEWLINE = "<br />";
        public static string SITENAME = "Mike Upjohn Web Portfolio V2";
        public static string IMAGEFILEPATH = "ImageFilePath";
        public static string UPLOADSIMAGEFILEPATH = ConfigurationManager.AppSettings[IMAGEFILEPATH];
        public static string DEFAULTIMAGEFILEPATH = "~/_includes//img//image-coming-soon.png";

        public class BodyClass
        {
            public static string HOMEPAGE = "homepage";
            public static string STANDARDCONTENT = "standard-content";
            public static string PROJECTS = "projects";
            public static string BLOGS = "blog";
            public static string TECHNOLOGIES = "technologies";
            public static string DETAILSPAGE = "detail-page";
            public static string CONTACTME = "contact-me";
        }

        public class Pages
        {
            public static string BLOGS = "blog/";
            public static string PROJECTS = "projects/";
        }
    }

    public class Emails
    {
        public class EmailAddress
        {
            public static string INFOMIKEUPJOHN = ConfigurationManager.AppSettings["InfoMikeUpjohn"];
        }

        public class Subjects
        {
            public static string CONTACTFORMENQUIRY = "Contact Form Enquiry";
            public static string THANKYOUFORYOURENQUIRY = "Thank you for your enquiry";
        }

        public class Body
        {
            public static string CONTACTFORMCLIENTEMAIL = "Dear Mike, {0}{0}Somebody has left an enquiry through your contact form. Their details are below:-{0}{0}<ul><li><b>Name: </b>{1}</li><li><b>E-mail Address: </b>{2}</li><li><b>Reason for Contact: </b>{3}</li><li><b>Message: </b>{4}</li><li><b>Sent from: </b>{5}</li><li><b>Send Date/Time: </b>{6}</li>";
            public static string CONTACTFORMUSEREMAIL = "Hi {1},{0}{0}This is just a quick message to let you know that your website enquiry has been received successfully. If necessary, expect a reply in 3 to 5 working days.{0}{0}Thanks,{0}Mike.";
        }
    }
}