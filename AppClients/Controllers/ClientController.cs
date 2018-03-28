using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppClients.Models;
using System.Diagnostics;

namespace AppClients.Controllers
{
    public class ClientController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();


        public ActionResult Index()
        {
            var clients = db.Clients.ToList();

            var Citys = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                Citys.Add(clients[i].City);
            }
            List<string> newCitys = new List<string>(Citys.Distinct());
            newCitys.Sort();
            SelectList citys = new SelectList(newCitys);
            ViewBag.Citys = citys;

            var FirstNames = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                FirstNames.Add(clients[i].FirstName);
            }
            List<string> newFirstNames = new List<string>(FirstNames.Distinct());
            newFirstNames.Sort();
            SelectList firstnames = new SelectList(newFirstNames);
            ViewBag.FirstNames = firstnames;
            IndexViewModel ivm = new IndexViewModel
            {
                Clients = db.Clients.ToList(),
                //Tasks = db.Tasks.ToList(),
            };
            return View(ivm);
        }

        public ActionResult FilterFirstName(string firstname)
        {
            var clients = db.Clients.ToList();

            var FirstNames = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                FirstNames.Add(clients[i].FirstName);
            }
            List<string> newFirstNames = new List<string>(FirstNames.Distinct());
            newFirstNames.Sort();
            SelectList firstnames = new SelectList(newFirstNames);
            ViewBag.FirstNames = firstnames;

            var Citys = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                Citys.Add(clients[i].City);
            }
            List<string> newCitys = new List<string>(Citys.Distinct());
            newCitys.Sort();
            SelectList citys = new SelectList(newCitys);
            ViewBag.Citys = citys;

            IndexViewModel ivm = new IndexViewModel
            {
                Clients = db.Clients.Where(b => b.FirstName == firstname).ToList(),
                Tasks = db.Tasks.ToList(),
            };
            return View("Index", ivm);
        }

        public ActionResult FilterCity(string city)
        {
            var clients = db.Clients.ToList();

            var FirstNames = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                FirstNames.Add(clients[i].FirstName);
            }
            List<string> newFirstNames = new List<string>(FirstNames.Distinct());
            newFirstNames.Sort();
            SelectList firstnames = new SelectList(newFirstNames);
            ViewBag.FirstNames = firstnames;

            var Citys = new List<string>();
            for (int i = 0; i <= clients.Count() - 1; i++)
            {
                Citys.Add(clients[i].City);
            }
            List<string> newCitys = new List<string>(Citys.Distinct());
            newCitys.Sort();
            SelectList citys = new SelectList(newCitys);
            ViewBag.Citys = citys;

            IndexViewModel ivm = new IndexViewModel
            {
                Clients = db.Clients.Where(b => b.City == city).ToList(),
                Tasks = db.Tasks.ToList(),
            };
            return View("Index", ivm);
        }

        [HttpPost]
        public ActionResult DeleteTask(int ClientId, int TaskId)
        {
            Client client = db.Clients.Find(ClientId);
            //newStudent.Name = student.Name;
            //newStudent.Surname = student.Surname;
            Task task = db.Tasks.Find(TaskId);
            client.Tasks.Remove(task);
            //получаем выбранные курсы
            //foreach (var c in db.Tasks.Where(co => co.Id != TaskId))
            //{
            //    client.Tasks.Add(c);
            //}

            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        
        //----------------------------------------------------

        public ActionResult CreateClient()
        {
            return View(new Client());
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index1");
            }

            return View(client);
        }

        // GET: Todos/Edit/5
        public ActionResult EditClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View(client);
        }

        public ActionResult DeleteClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedClient(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        //-------------------------------------------------------------------------------------------------
        public ActionResult CreateTask()
        {
            return View(new Task());
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index1");
            }

            return View(task);
        }

        // GET: Todos/Edit/5
        public ActionResult EditTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View(task);
        }

        public ActionResult DeleteTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTask(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
