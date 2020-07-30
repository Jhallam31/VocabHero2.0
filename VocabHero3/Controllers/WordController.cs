using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocabHero3.Models.WordModels;
using VocabHero3.Services;

namespace VocabHero3.Controllers
{
    public class WordController : Controller
    {
        // GET: Words
        public ActionResult Index()
        {

            var service = new WordService();
            var model = service.GetWords();

            return View(model);
        }

        //GET: Create
        //Word/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        //Word/Create

        [HttpPost]

        public ActionResult Create(WordCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var service = new WordService();

            service.CreateWord(model);

            return RedirectToAction("Index");
        }

        //Get: Details
        //Word/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateWordService();
            var model = svc.GetWordById(id);

            return View(model);
        }

        //Get: Edit
        //Word/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWordService();
            var detail = service.GetWordById(id);
            var model =
                new WordEdit
                {

                    WordName = detail.WordName,
                    Definition = detail.Definition,
                    PartOfSpeech = detail.PartOfSpeech
                };
            return View(model);
        }

        //POST: Edit
        //Word/Edit/{id}
        [HttpPost]

        public ActionResult Edit(string word, WordEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            //if (model.FlashCardId != id)
            //{
            //    ModelState.AddModelError("", "Flash card not found");
            //    return View(model);
            //}

            var service = CreateWordService();

            if (service.UpdateWord(model, word))
            {
                TempData["SaveResult"] = "Your flash card was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your card could not be updated.");
            return View(model);
        }

        //Get: Delete
        //WordDelete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWordService();
            var model = svc.GetWordById(id);

            return View(model);
        }

        //Post:Delete
        //Word/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeletePost(string word)
        {
            var service = CreateWordService();

            service.DeleteWord(word);

            TempData["SaveResult"] = "Your card was deleted";

            return RedirectToAction("Index");
        }

        private WordService CreateWordService()
        {

            var service = new WordService();
            return service;
        }
    }
}