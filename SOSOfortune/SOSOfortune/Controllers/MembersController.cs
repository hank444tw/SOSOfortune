using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SOSOfortune.Models;

namespace SOSOfortune.Controllers
{
    public class MembersController : Controller
    {
        private SOSOfortuneDataModel db = new SOSOfortuneDataModel();

        // GET: Members
        public ActionResult List()
        {
            return View(db.Member.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken] //預防跨網站攻擊
        public ActionResult Create([Bind(Include = "Name,Gender,Birthday,Email,Phone,Mem_id,Mem_password,Mem_confirmPassword")] Member member)
        {
            //Model驗證不通過
            if (ModelState.IsValid != true)
            {
                return View(member);
            }

            //呼叫GetRandomStringByGuid()產生亂碼
            member.Mem_guid = GetRandomStringByGuid();

            //以SHA1將密碼加密
            member.Mem_password = FormsAuthentication.HashPasswordForStoringInConfigFile(member.Mem_password, "SHA1");
            member.Mem_confirmPassword = member.Mem_password; //因為Model驗證，兩個欄位必須一樣，否則存不進資料庫

            db.Member.Add(member);
            db.SaveChanges();
            return RedirectToRoute("MemberList");
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Email,Phone,Mem_id,Mem_password,Mem_guid,Admin")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Member.Find(id);
            db.Member.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //驗證帳號是否重複
        [HttpPost]
        public ActionResult CheckMemId(string Mem_id)
        {
            var mem_id = db.Member.Where(m => m.Mem_id == Mem_id).FirstOrDefault();
            if (mem_id == null)
            {
                return Json(true); //沒重複
            }
            return Json(false); //重複
        }

        //使用guid產生亂碼
        public static string GetRandomStringByGuid()
        {
            string str = Guid.NewGuid().ToString().Replace("-", ""); //將"-"字號去掉
            return str;
        }
    }
}
