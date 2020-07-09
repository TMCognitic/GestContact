using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Interfaces;
using GestContact.Mvd.Models;
using GestContact.UI.Models.Client.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestContact.Mvd.Controllers
{
    public class ContactController : Controller
    {
        IContactServices<Contact> _contactServices;
        public ContactController(IContactServices<Contact> contactServices)
        {
            _contactServices = contactServices;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View(_contactServices.Get());
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View(_contactServices.Get(id));
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactForm form)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _contactServices.Insert(new Contact(form.Nom, form.Prenom, form.Email, form.Tel));
                    return RedirectToAction(nameof(Index));
                }                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(form);
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contact = _contactServices.Get(id);
            return View(new EditContactForm() { Id = contact.Id, Nom = contact.Nom, Prenom = contact.Prenom, Email = contact.Email, Tel = contact.Tel });
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditContactForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactServices.Update(id, new Contact(form.Nom, form.Prenom, form.Email, form.Tel));
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(form);
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            _contactServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
