using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SOSOfortune
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //首頁
            routes.MapRoute(
                name: "Index",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            //會員列表
            routes.MapRoute(
                name: "MemberList",
                url: "MemberList",
                defaults: new { controller = "Members", action = "List" }
            );

            //新增會員
            routes.MapRoute(
                name: "CreateMember",
                url: "CreateMember",
                defaults: new { controller = "Members", action = "Create" }
            );

            //修改會員
            routes.MapRoute(
                name: "EditMember",
                url: "EditMember/{id}",
                defaults: new { controller = "Members", action = "Edit" }
            );

            //刪除會員
            routes.MapRoute(
                name: "DeleteMember",
                url: "DeleteMember/{id}",
                defaults: new { controller = "Members", action = "Delete" }
            );

            //帳號驗證
            routes.MapRoute(
                name: "CheckMemId",
                url: "CheckMemId",
                defaults: new { controller = "Members", action = "CheckMemId" }
            );

            //登入
            routes.MapRoute(
                name: "Signin",
                url: "Signin",
                defaults: new { controller = "Members", action = "Signin" }
            );
        }
    }
}
