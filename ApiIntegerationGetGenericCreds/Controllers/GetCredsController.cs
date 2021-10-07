using ApiIntegerationGetGenericCreds.Models;
using CredentialManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiIntegerationGetGenericCreds.Controllers
{
    public class GetCredsController : Controller
    {
        // GET: GetCreds/Details/5
        public string Details(string id)
        {
            var data = GetCredential(id);

            UserDetails userDetails = new UserDetails
            {
                UserName = data.UserName,
                Password = data.Password,
            };

            string jsonString = JsonConvert.SerializeObject(userDetails);

            return jsonString;
        }

        // GET: GetCreds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GetCreds/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetCreds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GetCreds/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetCreds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GetCreds/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public static UserDetails GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                return null;
            }

            UserDetails userDetails = new UserDetails
            {
                UserName = cm.Username,
                Password = cm.Password,
            };

            return userDetails;
        }
    }
}
