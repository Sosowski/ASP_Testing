using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFriendcode.Models;

namespace MvcFriendcode.Controllers
{
    public class FriendCodesController : Controller
    {
        private FriendCodeDBContext db = new FriendCodeDBContext();

        //
        // GET: /FriendCodes/

        public ActionResult Index()
        {
            return View(db.FriendCodes.ToList());
        }

        //
        // GET: /FriendCodes/Details/5

        public ActionResult Details(int id = 0)
        {
            FriendCode friendcode = db.FriendCodes.Find(id);
            if (friendcode == null)
            {
                return HttpNotFound();
            }
            return View(friendcode);
        }

        //
        // GET: /FriendCodes/Create

        public ActionResult Create()
        {
            var u = new FriendCode();

            return View(u);
        }

        //
        // POST: /FriendCodes/Create

        [HttpPost]
        public ActionResult Create(FriendCode friendcode)
        {
            if (ModelState.IsValid)
            {
                db.FriendCodes.Add(friendcode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friendcode);
        }

        //
        // GET: /FriendCodes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FriendCode friendcode = db.FriendCodes.Find(id);
            if (friendcode == null)
            {
                return HttpNotFound();
            }
            return View(friendcode);
        }

        //
        // POST: /FriendCodes/Edit/5

        [HttpPost]
        public ActionResult Edit(FriendCode friendcode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendcode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendcode);
        }

        //
        // GET: /FriendCodes/Delete/5

        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            FriendCode friendcode = db.FriendCodes.Find(id);
            if (friendcode == null)
            {
                return HttpNotFound();
            }
            return View(friendcode);
        }

        //
        // POST: /FriendCodes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FriendCode friendcode = db.FriendCodes.Find(id);
            db.FriendCodes.Remove(friendcode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string FriendcodeCode, string searchString)
        {
            var CodeLst = new List<string>();

            var CodeQry = from d in db.FriendCodes
                          orderby d.Code
                          select d.Code;
            CodeLst.AddRange(CodeQry.Distinct());
            ViewBag.FriendcodeCode = new SelectList(CodeLst);

            var friendcodes = from m in db.FriendCodes
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                friendcodes = friendcodes.Where(s => s.User.Contains(searchString));
            }

            if (string.IsNullOrEmpty(FriendcodeCode))
                return View(friendcodes);
            else
            {
                return View(friendcodes.Where(x => x.Code == FriendcodeCode));
            }
        }
    }
}