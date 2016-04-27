using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureTime.Data.Abstract;
using AdventureTime.Data.Entities;
using System.Net;

namespace AdventureTime.Web.Controllers
{
    public class StoryController : Controller
    {
        private IStoryRepository storyRepo;
        private IParagraphRepository paraRepo;

        public StoryController(IStoryRepository storyRepository, IParagraphRepository paragraghRepository)
        {
            this.storyRepo = storyRepository;
            this.paraRepo = paragraghRepository;
        }
        // GET: Story
        public ActionResult List()
        {
            return View(storyRepo.Stories);
        }

        //Get method for creating a new story
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdventureTime_Story newStory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    storyRepo.SaveStory(newStory);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Story", "Create"));
            }

            return View();
        }

        public ViewResult Details(int id)
        {
            AdventureTime_Story story = storyRepo.Stories.FirstOrDefault(s => s.StoryID == id);

            return View(story);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            AdventureTime_Story story = storyRepo.Stories.FirstOrDefault(s => s.StoryID == id);
            return View(story);
        }

        [HttpPost]
        public ActionResult Edit(AdventureTime_Story story)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    storyRepo.SaveStory(story);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Story", "Edit"));
            }
            return View(story);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdventureTime_Story story = storyRepo.Stories.FirstOrDefault(s => s.StoryID == id);
            if (story.StoryID != id)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        [HttpPost]
        public ActionResult Delete(AdventureTime_Story story)
        {
            storyRepo.DeleteStory(story);
            return View("List");
        }

        public ActionResult Story()
        {
            return View();
        }

    }
}