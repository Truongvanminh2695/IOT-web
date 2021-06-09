using AutomaticWatering.Models;
using AutomaticWatering.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutomaticWatering.Controllers
{
    public class DashboardController : Controller
    {
        private int pageSize = 10;
        // GET: Dashboard
        public async Task<ActionResult> IndexAsync(int? page, DateTime? dateCreate)
        {
            // Check user login
            if (Session["UserName"] != null)
            {
                // Pagination
                if (page == null) page = 1;

                int pageNumber = (page ?? 1);

                // Get info channel
                var chanel = await WateringService.GetChanel();
                if(chanel == null)
                {
                    chanel = new Chanel()
                    {
                        Id = "1",
                        Created_At = DateTime.Now,
                        Description = "No description",
                        Last_Entry_Id = 0,
                        Name = "No get Chanel from API",
                        Updated_At = DateTime.Now
                    };
                }
                ViewBag.Chanel = chanel;

                // Get list info feed
                var lstFeed = await WateringService.GetListFeeds();

                if(dateCreate != null)
                {
                    var date = (DateTime)dateCreate;
                    lstFeed = lstFeed.Where(f => (f.CreateTime.Day == date.Day && 
                                                  f.CreateTime.Month == date.Month &&
                                                  f.CreateTime.Year == date.Year)).ToList();
                    ViewBag.dateCreate = dateCreate;
                }

                // Reverse
                lstFeed.Reverse();

                return View(lstFeed.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}