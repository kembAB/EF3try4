using System;
using MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models.Language.ViewModels;

using MVCWebApp.EFwk;

using MVCWebApp.Models.Language;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class LanguageController : Controller
    {
        public readonly personSeedDbContext _context;

        public LanguageController(personSeedDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AllLanguagesViewModel model = new AllLanguagesViewModel();
            model.LanguageList = _context.Languages.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LanguageviewModel CreateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_context.Languages.Find(CreateViewModel.LanguageName) == null)
                {
                    Language language = new Language();
                    language.LanguageName = CreateViewModel.LanguageName;

                    _context.Languages.Add(language);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                 
                    MessageViewModel messageModel = new MessageViewModel();
                    messageModel.Message = "Language already exists!";

                    return View("MessageView", messageModel);
                }
            }

           AllLanguagesViewModel model = new AllLanguagesViewModel();
            model.LanguageList = _context.Languages.ToList();

            return View(nameof(Index), model);
        }
    }
}

