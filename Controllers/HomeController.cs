using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstagramTokenRefresh.Models;
using InstagramTokenRefresh.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace InstagramTokenRefresh.Controllers
{
    public class HomeController : Controller
    {
       
        public JsonResult GetToken(int clientid)
        {
            var accessToken = "0";

            var optionsBuilder = new DbContextOptionsBuilder<InstagramDbContext>();
            optionsBuilder.UseSqlServer("Data Source=webs.bozell.com;Initial Catalog=Instagram;Persist Security Info=True;User ID=sa;Password=orajen1411!");

            var db = new InstagramDbContext(optionsBuilder.Options);
            var token = db.Tokens.Include("Client").SingleOrDefault(x => x.Id == clientid);

            if (token.DateModified < DateTime.Now.AddDays(-1))
            {
                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString("https://graph.instagram.com/refresh_access_token?grant_type=ig_refresh_token&access_token=" + token.AccessToken);


                    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<InstagramResponse>(response);

                    token.AccessToken = json.access_token;
                    token.DateModified = DateTime.Now;

                    
                    db.SaveChanges();
                }

            }



            return Json(token);
           
        }

    }
}
