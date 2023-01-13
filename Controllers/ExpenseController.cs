using Expensetracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expensetracker.Controllers
{
    public class ExpenseController : Controller
    {
        Expensecontext expensctx = new Expensecontext();
        // GET: Expense
        public ActionResult Index()
        {
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
            IList<Expense> expenselist = expensctx.expenses.ToList();
            return View(expenselist);
        }
        [HttpPost]
        public ActionResult Index(string category_name)
        {
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
            var data = expensctx.expenses.Where(model => model.Category_name == category_name).ToList();
            return View(data);

        }
        public ActionResult Create()
        {
            
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Expense e,Category c)
        {
            var getamount = expensctx.categories.Where(x => x.Category_name == e.Category_name).FirstOrDefault();
            if (getamount.Category_expense_limit > e.Amount)
            {
                List<Category> ctlist = expensctx.categories.ToList();
                TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
                if (ModelState.IsValid)
                {
                    expensctx.expenses.Add(e);
                    int a = expensctx.SaveChanges();
                    if (a > 0)
                    {
                        TempData["insertmsg"] = "<script>alert('Date inserted..!!')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.insertmsg = "<script>alert('Data not inserted--!!')</script>";
                        return View();
                    }
                }
            }
            else
            {
                List<Category> ctlist = expensctx.categories.ToList();
                TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
                ViewBag.msg="<script>alert('category limit check')</script>";
                return View();
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
            var row = expensctx.expenses.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Expense e)
        {
            expensctx.Entry(e).State = EntityState.Modified;
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
            int a=expensctx.SaveChanges();
            if (a > 0)
            {
                TempData["updatmsg"] = "<script>alert('Date updated..!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.updatmsg = "<script>alert('Data not updated--!!')</script>";
                return View();
            }
        }
       
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var rowdelete = expensctx.expenses.Where(model => model.Id == id).FirstOrDefault();
                if(rowdelete != null)
                {
                    expensctx.Entry(rowdelete).State = EntityState.Deleted;
                    int a = expensctx.SaveChanges();
                    if(a>0)
                    {
                        TempData["Deleted"] = "<script>alert('Data Deleted..!!')</script>";
                    }
                    else
                    {
                        TempData["Deleted"] = "<script>alert('Data not Deleted..!!')</script>";
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult Categories()
        {
            var categorylist = GetCategories();
            return PartialView("_categories", categorylist);
        }
        public PartialViewResult Totalexpenselimit()
        {
            var totalexpenselimit = GetExpense_Limits();
            return PartialView("_expenselimit", totalexpenselimit);
        }
        public List<Category> GetCategories()
        {
            return expensctx.categories.ToList();
        }
        public List<Expense_limit> GetExpense_Limits()
        {
            return expensctx.expense_limits.ToList();
        }
    }
}