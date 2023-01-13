using Expensetracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expensetracker.Controllers
{
    public class ExpenselimitController : Controller
    {
        Expensecontext expensctx = new Expensecontext();
        // GET: Expenselimit
        public ActionResult Index()
        {
            IList<Expense_limit> expenselimitlist = expensctx.expense_limits.ToList();
            return View(expenselimitlist);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Expense_limit e)
        {
            expensctx.expense_limits.Add(e);
            int a=expensctx.SaveChanges();
            if (a > 0)
            {
                TempData["insertmsg"] = "<script>alert('Data Inserted..!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["insertmsg"] = "<script>alert('Data not Inserted..!!')</script>";
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var row = expensctx.expense_limits.Where(model => model.e_id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Expense_limit ex)
        {
            expensctx.Entry(ex).State = EntityState.Modified;
            int a=expensctx.SaveChanges();
            if (a > 0)
            {
                TempData["updatemsg"] = "<script>alert('Data updated..!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["updatemsg"] = "<script>alert('Data not updated..!!')</script>";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var rowdelete = expensctx.expense_limits.Where(model => model.e_id == id).FirstOrDefault();
                if (rowdelete != null)
                {
                    expensctx.Entry(rowdelete).State = EntityState.Deleted;
                    int a = expensctx.SaveChanges();
                    if (a > 0)
                    {
                        TempData["Del"] = "<script>alert('Data Deleted..!!')</script>";
                    }
                    else
                    {
                        TempData["Del"] = "<script>alert('Data not Deleted..!!')</script>";
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}