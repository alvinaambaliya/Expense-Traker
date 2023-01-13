using Expensetracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expensetracker.Controllers
{
    public class CategoryController : Controller
    {
        Expensecontext expensctx = new Expensecontext();

        // GET: Category
        public ActionResult Index()
        {
            IList<Category> categorylist = expensctx.categories.ToList();
            
            return View(categorylist);
        }
        public ActionResult Create()
        {
            List<Category> ctlist = expensctx.categories.ToList();
            TempData["categoryddlist"] = new SelectList( ctlist, "Category_name", "Category_name") ;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            expensctx.categories.Add(c);
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
        [HttpGet]
        public ActionResult Edit(string Category_name)
        {
  
            var row = expensctx.categories.Where(model => model.Category_name == Category_name).FirstOrDefault();
            return View(row);
        }
        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Category_name")]Category c)
        //{
        //    if(ModelState.IsValid)
        //        {
        //        List<Category> ctlist = expensctx.categories.ToList();
        //        TempData["categoryddlist"] = new SelectList(ctlist, "Category_name", "Category_name");
        //        string OCategory_name = Request["Category_name"].ToString();
        //        var row = expensctx.categories.Where(model => model.Category_name == OCategory_name);
        //        foreach(var i in row)
        //        {
        //            expensctx.categories.Remove(i);
        //        }
        //        expensctx.categories.Add(c);
        //        try
        //        {
        //            expensctx.SaveChanges();
        //        }
        //        catch
        //        {
        //            return RedirectToAction("Index");
        //        }
                
        //        expensctx.Entry(c).State = EntityState.Modified;
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.categorynm = new SelectList(expensctx.categories, "Category_name", c.Category_name);
        //    return View(c);
        //}
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            expensctx.Entry(c).State = EntityState.Modified;
            try
            {
                int a = expensctx.SaveChanges();
                if (a > 0)
                {
                    ViewBag.updatemessage = "<script>alert('Date updated !!')</script>";
                }
                else
                {
                    ViewBag.updatemessage = "<script>alert('Data not updated !!')</script>";
                    return View();
                }
            }
            catch
            {
                TempData["msg"] = "<script>alert('you can't edit your category name only edit limit  !!')</script>";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        ////public ActionResult Edit(string id,Category c)
        //{
        //    //var row = expensctx.categories.Where(model => model.Category_name == id).FirstOrDefault();
        //   // expensctx.categories.Remove(row);
        //    //expensctx.categories.Add(c);
        //    expensctx.Entry(c).State = EntityState.Modified;
        //    int a = expensctx.SaveChanges();
        //    if (a > 0)
        //    {
        //        ViewBag.updatemessage = "<script>alert('Date updated !!')</script>";
        //    }
        //    else
        //    {
        //        ViewBag.updatemessage = "<script>alert('Data not updated !!)</script>";
        //        return View();
        //    }
        //    return RedirectToAction("Index");

        //}
        //public ActionResult Edit([Bind(Include="id")]Category c)
        //{
        //   // var row = expensctx.categories.Where(model => model.Category_name == cname).FirstOrDefault();
        //   if(ModelState.IsValid)
        //    {
        //        string Oid = Request["id"];
        //        var rowupdate = expensctx.categories.Where(model => model.Category_name == Oid).FirstOrDefault();
        //        //foreach (var i in rowupdate)
        //        //{
        //        //    expensctx.categories.Remove(i);
        //        //}
        //        expensctx.categories.Remove(rowupdate);
        //        //expensctx.Entry(c).State = EntityState.Modified;
        //        expensctx.categories.Add(c);
        //        expensctx.Entry(c).State = EntityState.Modified;
        //        //try
        //        //{
        //        //    expensctx.SaveChanges();
        //        //}
        //        //catch
        //        //{
        //        //    return RedirectToAction("Index");
        //        //}
        //        // expensctx.Entry(c).State = EntityState.Modified;
        //        expensctx.SaveChanges();
        //        ViewBag.id = new SelectList(expensctx.categories, "Category_name", "Category_expense_limit", c.Category_name);
        //        //return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(string Category_name)
        {
            var row = expensctx.categories.Where(model => model.Category_name == Category_name).FirstOrDefault();
            if(row != null)
            {
                expensctx.Entry(row).State = EntityState.Deleted;
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
            return RedirectToAction("Index");
        }
    }
}