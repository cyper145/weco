using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using prueba4.Models;

namespace prueba4.Model {
    public class ApplicationUser {
        public string UserName { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }

    public static class AuthHelper {

     
        public static bool SignIn(string userName, string password) {

            
                using (Models.dbwencoEntities db = new Models.dbwencoEntities())
                {
                    Dk_user userData = (from d in db.Dk_user
                                 where d.email == userName.Trim() && d.password == password.Trim()
                                 select d).FirstOrDefault();
               
                if (userData == null)
                {
                    return false;
                }
                else
                {
                    HttpContext.Current.Session["User"] = userData;
                    HttpContext.Current.Session["Rol"] = userData.rol_id;
                    return true;
                }
               
                }
         
            
        }
        public static void SignOut() {
            HttpContext.Current.Session["User"] = null;
            HttpContext.Current.Session["Rol"] = null;
        }
        public static bool IsAuthenticated() {
            return GetLoggedInUserInfo() != null;
        }

        public static Dk_user GetLoggedInUserInfo() {
            return HttpContext.Current.Session["User"] as Dk_user;
        }
        private static ApplicationUser CreateDefualtUser() {
            return new ApplicationUser {
                UserName = "JBell",
                FirstName = "Julia",
                LastName = "Bell",
                Email = "julia.bell@example.com",
                AvatarUrl = "~/Content/Photo/Julia_Bell.jpg"
            };
        }
    }
}