using MikeUpjohnWebPortfolioV2.Code;
using MikeUpjohnWebPortfolioV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult _ContactForm()
        {
            ContactForm form = new ContactForm();
            form.EnquiryOptions = new List<SelectListItem>() {
                new SelectListItem() { Value = "I have an enquiry or question", Text = "I have an enquiry or question" },
                new SelectListItem() {Value = "I've spotted a mistake", Text="I've spotted a mistake" },
                new SelectListItem() { Value = "I am looking for a developer", Text = "I am looking for a developer" },
                new SelectListItem() { Value = "Other enquiry", Text = "Other enquiry" },
            };

            return PartialView(form);
        }

        [ChildActionOnly]
        public PartialViewResult _Footer()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _ContactForm(ContactForm form)
        {
            if(ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient();

                MailMessage clientMail = new MailMessage();
                //clientMail.From = new MailAddress(Code.Emails.EmailAddress.INFOMIKEUPJOHN);
                clientMail.To.Add(Code.Emails.EmailAddress.INFOMIKEUPJOHN);
                clientMail.Subject = Code.Emails.Subjects.CONTACTFORMENQUIRY;
                clientMail.IsBodyHtml = true;
                clientMail.Body = string.Format(Code.Emails.Body.CONTACTFORMCLIENTEMAIL, Code.Settings.HTMLNEWLINE, form.Name, form.Email, form.SelectedEnquiryOption, form.Message, System.Web.HttpContext.Current.Request.Url.AbsoluteUri, DateTime.Now.ToString("dddd dd MMMM yyyy hh:mm:ss"));

                MailMessage userMail = new MailMessage();
                //userMail.From = new MailAddress(Code.Emails.EmailAddress.INFOMIKEUPJOHN);
                userMail.To.Add(form.Email);
                userMail.Subject = Code.Emails.Subjects.THANKYOUFORYOURENQUIRY;
                userMail.IsBodyHtml = true;
                userMail.Body = string.Format(Code.Emails.Body.CONTACTFORMUSEREMAIL, Code.Settings.HTMLNEWLINE, form.Name);

                client.Send(clientMail);
                client.Send(userMail);

                return RedirectToAction("Index", "Thankyou");
            }

            return null;
        }

        [ChildActionOnly]
        public PartialViewResult _Pagination(int currentPage, int countOfItems)
        {
            string currentURL = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            int indexOfPaginationURL = currentURL.IndexOf("/page-");

            if(indexOfPaginationURL > 0) {
                currentURL = currentURL.Substring(0, indexOfPaginationURL);
            }

            currentURL = !(currentURL.EndsWith("/")) ? currentURL + "/" : currentURL;

            ViewBag.CurrentPage = currentPage;
            ViewBag.CurrentPageURL = currentURL;
            ViewBag.MaximumPage = Math.Ceiling((double)countOfItems / Settings.PAGINATIONITEMSPERPAGE);
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _MainNavigation()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _MobileNavigation()
        {
            return PartialView();
        }
    }
}